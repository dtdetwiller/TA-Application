const chart = Highcharts.chart('chart', {

    title: {
        text: 'Course Enrollment Over Time'
    },

    yAxis: {
        title: {
            text: 'Number of Students Enrolled'
        }
    },

    xAxis: {
        type: "datetime",
        title: {
            text: 'Dates'
        },
    },

    legend: {
        layout: 'vertical',
        align: 'right',
        verticalAlign: 'middle'
    },

    plotOptions: {
        series: {
            label: {
                connectorAllowed: false
            },
            pointInterval: 3600 * 1000 * 24,
            pointStart: Date.UTC(2021, 10, 1),
        }
    },

    responsive: {
        rules: [{
            condition: {
                maxWidth: 500
            },
            chartOptions: {
                legend: {
                    layout: 'horizontal',
                    align: 'center',
                    verticalAlign: 'bottom'
                }
            }
        }]
    }
});

var dataToAdd = [];

function getEnrollmentData(startDate, endDate, course) {

    document.getElementById("spinner").style.display = "block";

    this.startDate = startDate;
    this.endDate = endDate;

    // Disable the date entries when button is clicked.
    document.getElementById("startDate").disabled = true;
    document.getElementById("endDate").disabled = true;

    // Separate the start date
    const startDateSep = startDate.split("-");
    let startYear = startDateSep[0];
    let startMonth = startDateSep[1];
    let startDay = startDateSep[2];

    // Separate the end date
    const endDateSep = endDate.split("-");
    let endYear = endDateSep[0];
    let endMonth = endDateSep[1];
    let endDay = endDateSep[2];

    chart.xAxis[0].setExtremes(Date.UTC(startYear, startMonth - 1, startDay), Date.UTC(endYear, endMonth - 1, endDay));

    var data = {
        startDate: startDate,
        endDate: endDate,
        course: course
    }

    $.post("/Admin/GetEnrollmentData", data)
        .done(function (result) {
            dataToAdd = result.returnedEnrollments.value;
            console.log(dataToAdd);

            if (Date.UTC(startYear, startMonth - 1, startDay) >= Date.UTC(2021, 10, 1)) {

                addSeries(course, dataToAdd, Date.UTC(startYear, startMonth - 1, startDay), Date.UTC(endYear, endMonth - 1, endDay));
            }
            else {
                
                addSeries(course, dataToAdd, Date.UTC(startYear, 10, 1), Date.UTC(endYear, endMonth - 1, endDay));
            }

            document.getElementById("spinner").style.display = "none";

        })
}

function addSeries(name, data, startDate) {

    chart.addSeries(
        {
            pointStart: startDate,
            pointEnd: endDate,
            data: data,
            name: name,
        });
}

document.getElementById("spinner").style.display = "none";