
// Illustrates calling the Lingo DLL from C# to
// solve the simple product mix model:
//
//    Max 100 Standard + 150 Turbo;
//    S.T.
//       Standard <= 100
//       Turbo <= 120
//       Standard + 2 * Turbo < 160;
//      

using System;
using System.IO;
using System.Runtime.InteropServices;
using DTO;

// Our data structure to pass to the callback function
//[StructLayout(LayoutKind.Sequential)]
public struct CallbackData
{
    public int nCallbacks;
    public int nIterations;
    public double dObjective;
}

public class CTRLingo
{
    // We need memory pointers to pass data to and from Lingo.
    // In order to work with pointers, a routine must be declared "unsafe".
    public unsafe void Main(DTOB dtoB)
    {
        int nError = -1, nPointersNow = -1;
        const string strModelFile = "E:\\2022 - 1\\io\\PROYECTO LINGO\\ZOOLOGICO_BD\\ZOOLOGICO_IO_BD.lng"; // Model file name

        // Make sure model file exists
        if (!File.Exists(strModelFile))
        {
           dtoB.estado = 0;
           dtoB.Msj = strModelFile;
           //Console.WriteLine("*** Unable to find model file: {0}\n", strModelFile);
           goto FinalExit;
        }

        // Get a pointer to a Lingo environment
        IntPtr pLingoEnv; 
        pLingoEnv = lingo.LScreateEnvLng();
        if (pLingoEnv == IntPtr.Zero)
        {
            dtoB.estado = 1;
            //Console.WriteLine( "Unable to create Lingo environment.\n");
            goto FinalExit;
        }

        // Open LINGO's log file  
        nError = lingo.LSopenLogFileLng( pLingoEnv, "E:\\2022 - 1\\io\\PROYECTO LINGO\\ZOOLOGICO_BD\\ZOOLOGICO_IO_G6.mdf");
        if (nError != lingo.LSERR_NO_ERROR_LNG) goto ErrorExit;

        // In the code below, we establish our callback functions. The solver
        // callback is called periodically by the solver when the model is processing.
        // The error callback is called whenever Lingo encounters an error.
        // Callbacks are optional -- you do not have to declare them if they aren't
        // needed.

        // Optionally, declare our callback data (allocate on global
        // heap to keep gc from relocating)
        CallbackData cbData;
        cbData.nCallbacks = 0;
        cbData.nIterations = -1;
        cbData.dObjective = 0.0;
        IntPtr myData = Marshal.AllocHGlobal( Marshal.SizeOf( cbData));
        Marshal.StructureToPtr(cbData, myData, true);

        // Pass a pointer to the solver callback and our data
        //lingo.typCallback cb = new lingo.typCallback(CTRLingo.MyCallback);
        //nError = lingo.LSsetCallbackSolverLng( pLingoEnv, cb, myData);
        //if ( nError != lingo.LSERR_NO_ERROR_LNG) goto ErrorExit;

        // Pass a pointer to the error callback and our data
        //lingo.typCallbackError cbError = new lingo.typCallbackError(CTRLingo.MyErrorCallback);
        //nError = lingo.LSsetCallbackErrorLng(pLingoEnv, cbError, myData);
        //if (nError != lingo.LSERR_NO_ERROR_LNG) goto ErrorExit;

        // Must pin lingo's transfer areas in memory to keep GC from relocating. C#
        // is a memory managed language. This means it's garbage collector could relocate
        // Lingo's transfer areas if they are not pinned.

        // Each of the memory locations below are accessed by Lingo's @POINTER( n) function
        // in the Lingo model, where n is the index of the memory location of interest.

        fixed (double* pdProfit = new double[2] {100, 150})
        fixed (double* pdLimit = new double[2] {100, 200})
        fixed (double* pdLabor = new double[2] {1, 2})
        fixed (double* pdObjective = new double[1] {-1})
        fixed (double* pdStatus = new double[1] {-1})
        fixed (double* pdProduce = new double[2] {-1, -1})
        fixed (byte* pcComputers = new byte[64])
        {

            // Load the set of computer names (separated by \n)
            string strComputers = "STANDARD\nTURBO";
            for (int i = 0; i < strComputers.Length; i++) pcComputers[i] = (byte)strComputers[i]; 
            pcComputers[ strComputers.Length] = 0;

            // Pass Lingo the addresses of the transfer areas for input and output data:

            // Pass Lingo the pointer to the objective coefficients (refer
            // to the template model, simple.lng)
            nError = lingo.LSsetPointerLng( pLingoEnv, pdProfit, ref nPointersNow); 
            if ( nError != lingo.LSERR_NO_ERROR_LNG) goto ErrorExit;
                    
            // Pass a pointer to the production limits
            nError = lingo.LSsetPointerLng( pLingoEnv, pdLimit, ref nPointersNow); 
            if ( nError != lingo.LSERR_NO_ERROR_LNG) goto ErrorExit;

            // Pointer to the labor utilization coefficients
            nError = lingo.LSsetPointerLng( pLingoEnv, pdLabor, ref nPointersNow); 
            if ( nError != lingo.LSERR_NO_ERROR_LNG) goto ErrorExit;

            // Point to dObjective, where Lingo will return the objective value
            nError = lingo.LSsetPointerLng( pLingoEnv, pdObjective, ref nPointersNow); 
            if ( nError != lingo.LSERR_NO_ERROR_LNG) goto ErrorExit;

            // Pointer to the solution status code
            nError = lingo.LSsetPointerLng( pLingoEnv, pdStatus, ref nPointersNow); 
            if ( nError != lingo.LSERR_NO_ERROR_LNG) goto ErrorExit;

            // Point to the variable value array
            nError = lingo.LSsetPointerLng( pLingoEnv, pdProduce, ref nPointersNow);
            if (nError != lingo.LSERR_NO_ERROR_LNG) goto ErrorExit;

            // Point to the set members
            nError = lingo.LSsetPointerLng(pLingoEnv, pcComputers, ref nPointersNow);
            if (nError != lingo.LSERR_NO_ERROR_LNG) goto ErrorExit;

            // Here is the script we want LINGO to run. This "take" command loads the
            // model from an external file. Alternatively, cScript could have been loaded
            // with the model text, avoiding a file access.
            string cScript = "set echoin 1 \n";
            cScript += "take " + strModelFile + "\n";
            cScript += "go \n"; 
            cScript += "quit \n";

            // Clear out the status value;
            pdStatus[ 0] = -1;

            // Run the script. The error code here only pertains to whether the script
            // was successfuly loaded for processing. We check the actual status of the
            // solution below by checking the status value returned by Lingo in pdStatus.
            nError = lingo.LSexecuteScriptLng( pLingoEnv, cScript);
            if ( nError != lingo.LSERR_NO_ERROR_LNG)
            {
               lingo.LScloseLogFileLng(pLingoEnv);
               goto ErrorExit;
            }

            // Close the log file
            lingo.LScloseLogFileLng( pLingoEnv);

            // Any problems?
            if ( nError != 0 /*||
            // Check for optimal solution
            pdStatus[ 0] != lingo.LS_STATUS_GLOBAL_LNG*/)
            {
                // Had a problem   
                //Console.WriteLine( "Unable to solve!");
                dtoB.estado = 2;
            } else  {
                // Everything went OK ... print results
                //Console.WriteLine(
                //"\nStandards: {0} \nTurbos: {1} \n\nProfit: {2}",
                // pdProduce[0], pdProduce[1], pdObjective[0]);
                dtoB.estado = 3;
            }
        }

       

        // Marshal callnack data back to the structure
        cbData = (CallbackData) Marshal.PtrToStructure(myData,typeof(CallbackData));
        //Console.WriteLine( "Total callbacks : {0}" , cbData.nCallbacks);

        // free user data in global heap
        Marshal.FreeHGlobal( myData);

        goto NormalExit;

    ErrorExit:
        //Console.WriteLine( "LINGO Error Code: {0}\n", nError);
        dtoB.estado = 4;
        dtoB.Msj = ""+nError;

    NormalExit:
        // Free Lingo's envvironment to avoid a memory leak
        lingo.LSdeleteEnvLng(pLingoEnv);

    FinalExit:
        Console.WriteLine("\nPress enter...");
    //    String sTemp = Console.ReadLine();
    }
    //public static int MyCallback(IntPtr pLingoEnv, int nLoc, IntPtr myData)
    //{
    //    // copy the user data in the unmanaged code into a local structure
    //    CallbackData cb = (CallbackData)Marshal.PtrToStructure(myData, typeof(CallbackData));

    //    // increment the number of calls to the callback function
    //    cb.nCallbacks++;

    //    // get iteration count
    //    int nIterations = -1, nErr;
    //    nErr = lingo.LSgetCallbackInfoLng(pLingoEnv,
    //     lingo.LS_IINFO_ITERATIONS_LNG, ref nIterations);
    //    if (nErr == lingo.LSERR_NO_ERROR_LNG && nIterations != cb.nIterations)
    //    {
    //        cb.nIterations = nIterations;
    //        //Console.WriteLine("Current iteration count in callback={0}", nIterations);
    //    }

    //    // get current objective
    //    double dObjective = 0.0;
    //    nErr = lingo.LSgetCallbackDblInfoLng(pLingoEnv,
    //     lingo.LS_DINFO_OBJECTIVE_LNG, ref dObjective);
    //    if (nErr == lingo.LSERR_NO_ERROR_LNG && dObjective != cb.dObjective && dObjective > 0.0)
    //    {
    //        cb.dObjective = dObjective;
    //        //Console.WriteLine("Current objective in callback={0}", dObjective);
    //    }

    //    // copy the user data in the local structure back to the unmanaged code
    //    Marshal.StructureToPtr(cb, myData, false);

    //    // can return -1 here to interrupt the solver
    //    return 0;
    //}

    //public static int MyErrorCallback(IntPtr pLingoEnv, IntPtr myData, int nErrorCode, string strErrorMessage)
    //{
    //   copy the user data in the unmanaged code into a local structure
    //   CallbackData cb = (CallbackData)Marshal.PtrToStructure(myData, typeof(CallbackData));
    //   //Console.WriteLine("*** Lingo Error Message: ");
    //   Console.WriteLine( strErrorMessage + "\n");
    //   return 0;
    //}
   
}