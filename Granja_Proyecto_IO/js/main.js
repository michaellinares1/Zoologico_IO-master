/*Animaciones con javascript*/
const animateCSS = (element, animation, prefix = "animate__") =>
    // We create a Promise and return it
    new Promise((resolve, reject) => {
        const animationName = `${prefix}${animation}`;
        const node = document.querySelector(element);

        node.classList.add(`${prefix}animated`, animationName);

        // When the animation ends, we clean the classes and resolve the Promise
        function handleAnimationEnd() {
            node.classList.remove(`${prefix}animated`, animationName);
            node.removeEventListener("animationend", handleAnimationEnd);

            resolve("Animation ended");
        }

        node.addEventListener("animationend", handleAnimationEnd);
    });

window.onload = function () {
    const panel = document.querySelector(".panel");
    const body = document.querySelector("body");
    animateCSS(".panel", "fadeOutUp").then((message) => {
        // Do something after the animation
        panel.classList.add("d-none");
        body.classList.remove("body-over");
    });
};


document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('input[type=text]').forEach(node => node.addEventListener('keypress', e => {
        if (e.keyCode == 13) {
            e.preventDefault();
        }
    }))
});


$(document).ready(function () {
    $("#MainContent_btnSolver").on("click", GenerarSolucion);
}); 

function GenerarSolucion() {
    $("body").addClass("body-over");
    $(".panel").removeClass("d-none");
    $(".panel").addClass("animate__animated animate__fadeInDown animate__faster");
    var respuesta;
    $.ajax({
        type: "post",
        url: '/Pages/Inicio.aspx/GenerarSolucion',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            respuesta = jQuery.parseJSON(response.d);

            if (respuesta.estado == 0) {
                $(".panel").addClass("d-none");
                $("body").removeClass("body-over");
                    Swal.fire({
                        icon: 'error',
                        showCloseButton: true,
                        title: 'No se encontro el archivo',
                        text: 'Archivo: ' + respuesta.Msj,
                        showConfirmButton: false,
                    })
            }
            if (respuesta.estado == 1) {
                $(".panel").addClass("d-none");
                $("body").removeClass("body-over");
                Swal.fire({
                    icon: 'error',
                    showCloseButton: true,
                    title: 'Unable to creare Lingo Enviroment',
                    showConfirmButton: false,
                })
            }
            if (respuesta.estado == 2) {
                $(".panel").addClass("d-none");
                $("body").removeClass("body-over");
                Swal.fire({
                    icon: 'error',
                    showCloseButton: true,
                    title: 'Enabled to solve',
                    showConfirmButton: false,
                })

            }
            if (respuesta.estado == 3) {
                animateCSS(".panel", "fadeOutUp").then((message) => {
                    $(".panel").addClass("d-none");
                    $("body").removeClass("body-over");
                    Swal.fire({
                        icon: 'success',
                        showCloseButton: true,
                        title: 'Solucion Generada Correctamente',
                        showConfirmButton: false,
                    }).then((result) => {
                        location.href = '/Reporte';
                    })
                });
            }
            if (respuesta.estado == 4) {
                $(".panel").addClass("d-none");
                $("body").removeClass("body-over");
                Swal.fire({
                    icon: 'error',
                    showCloseButton: true,
                    title: 'Lingo Error',
                    text: 'Error Code: ' + respuesta.Msj,
                    showConfirmButton: false,
                })

            }
        }
    });
}
