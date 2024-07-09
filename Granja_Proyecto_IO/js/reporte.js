var hdnCostoFinal = document.getElementById("hdnCostoFinal").value;
var cost1 = document.getElementById("hdnCost1").value;
var cost2 = document.getElementById("hdnCost2").value;
var cost3 = document.getElementById("hdnCost3").value;

var ctx = document.getElementById('salesData').getContext("2d");
var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["Periodo 1", "Periodo 2", "Periodo 3"],
        datasets: [
            {
                label: "Costo",
                radius: 6,
                borderWidth: 2,
                backgroundColor: [
                    "rgba(195, 40, 96, 0.1)",
                    "rgba(255, 172, 100, 0.1)",
                    "rgba(19, 71, 34, 0.3)"
                ],
                borderColor: [
                    "rgba(195, 40, 96, 1)",
                    "rgba(255, 172, 100, 1)",
                    "rgba(88, 188, 116, 1)"
                ],
                data: [cost1, cost2, cost3],
            }
        ]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        },
        title: {
            display: true,
            text: 'Costos por periodo',
            fontColor: '#fff',
        },
        legend: {
            display: false
        }
    }
});

var result1 = cost1 / hdnCostoFinal;
var result2 = cost2 / hdnCostoFinal;
var result3 = cost3 / hdnCostoFinal;

//Credit Sales
var creditSales = new ProgressBar.Circle('#creditSales', {
    color: '#e81760',
    strokeWidth: 3,
    trailWidth: 3,
    duration: 1500,
    text: {
        value: '0%'
    },
    step: function (state, bar) {
        bar.setText((bar.value() * 100).toFixed(0) + "%");
    }
});
var channelSales = new ProgressBar.Circle('#channelSales', {
    color: '#e88e3c',
    strokeWidth: 3,
    trailWidth: 3,
    duration: 1500,
    text: {
        value: '0%'
    },
    step: function (state, bar) {
        bar.setText((bar.value() * 100).toFixed(0) + "%");
    }
});
var directSales = new ProgressBar.Circle('#directSales', {
    color: '#2bab51',
    strokeWidth: 3,
    trailWidth: 3,
    duration: 1500,
    text: {
        value: '0%'
    },
    step: function (state, bar) {
        bar.setText((bar.value() * 100).toFixed(0) + "%");
    }
});

creditSales.animate((result1));
channelSales.animate((result2));
directSales.animate((result3));