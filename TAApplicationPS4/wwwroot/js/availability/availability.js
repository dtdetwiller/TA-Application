
/** Globals */
var monday = "";
var tuesday = "";
var wednesday = "";
var thursday = "";
var friday = "";

var days = [];

class Availability extends PIXI.Graphics {

    constructor(mon, tue, wed, thu, fri) {
        super();

        // Draw monday column
        this.draw_day(50, mon, "monday");

        // Draw tuesday column
        this.draw_day(150, tue, "tuesday");

        // Draw wednesday column
        this.draw_day(250, wed, "wednesday");

        // Draw thursday column
        this.draw_day(350, thu, "thursday");

        // Draw friday column
        this.draw_day(450, fri, "friday");

        this.draw_lines();

    }

    /**
     * Draws timeslots for each day
     * */
    draw_day(position, day, dayType) {
        let _day = new Day(day, position, dayType);
        days.push(_day);
        app.stage.addChild(_day);
    }

    draw_lines() {
        for (let i = 0; i < 13; i++) {
            this.lineStyle(1, 0x000000);
            this.moveTo(25, i * 32 + 58);
            this.lineTo(550, i * 32 + 58);
            this.endFill();
            app.stage.addChild(this);

            // Add the times on the side
            if (i == 0) {
                let text = new PIXI.Text('8:00am', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 1) {
                let text = new PIXI.Text('9:00am', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 2) {
                let text = new PIXI.Text('10:00am', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 3) {
                let text = new PIXI.Text('11:00am', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 4) {
                let text = new PIXI.Text('12:00am', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 5) {
                let text = new PIXI.Text('1:00pm', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 6) {
                let text = new PIXI.Text('2:00pm', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 7) {
                let text = new PIXI.Text('3:00pm', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 8) {
                let text = new PIXI.Text('4:00pm', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 9) {
                let text = new PIXI.Text('5:00pm', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 10) {
                let text = new PIXI.Text('6:00pm', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 11) {
                let text = new PIXI.Text('7:00pm', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
            else if (i == 12) {
                let text = new PIXI.Text('8:00pm', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
                text.x = 560;
                text.y = i * 32 + 50;
                app.stage.addChild(text);
            }
        }

        // Add the days text
        let monText = new PIXI.Text('Monday', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
        monText.x = 60;
        monText.y = 30;
        app.stage.addChild(monText);

        let tueText = new PIXI.Text('Tuesday', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
        tueText.x = 160;
        tueText.y = 30;
        app.stage.addChild(tueText);

        let wedText = new PIXI.Text('Wednesday', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
        wedText.x = 248;
        wedText.y = 30;
        app.stage.addChild(wedText);

        let thuText = new PIXI.Text('Thursday', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
        thuText.x = 355;
        thuText.y = 30;
        app.stage.addChild(thuText);

        let friText = new PIXI.Text('Friday', { fontFamily: 'Arial', fontSize: 16, fill: 0x000000, align: 'center' });
        friText.x = 465;
        friText.y = 30;
        app.stage.addChild(friText);

    }

}

function updateAvailability(userid) {

    // remove the unsaved data message when the button is clicked.
    var child = app.stage.getChildByName("savedText");
    if (child != null) {
        app.stage.removeChild(child);
    }

    var data =
    {
        userid: userid,
        monday: days[0].get_slots,
        tuesday: days[1].get_slots,
        wednesday: days[2].get_slots,
        thursday: days[3].get_slots,
        friday: days[4].get_slots
    }

    $("#spinner").show();

    $.post("/Availability/GetSchedule", data)
        .done(function () {
            wait(1000);
            $("#spinner").hide();
        })
        .fail(function () {

        })
}

/*
 * A wait function.
 */
function wait(ms) {
    var start = new Date().getTime();
    var end = start;
    while (end < start + ms) {
        end = new Date().getTime();
    }
}

function retrieveData(monday, tuesday, wednesday, thursday, friday) {

    console.log(monday);
    this.monday = monday;
    this.tuesday = tuesday;
    this.wednesday = wednesday;
    this.thursday = thursday;
    this.friday = friday;

    start();
}

function start() {
    $("#spinner").hide();
    setup_pixi_stage(700, 500);
    app.stage.addChild(new Availability(this.monday, this.tuesday, this.wednesday, this.thursday, this.friday));
}