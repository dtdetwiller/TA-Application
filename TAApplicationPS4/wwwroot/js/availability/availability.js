// Main class for the Availability GUI

/** Globals */
var monday = "";
var tuesday = "";
var wednesday = "";
var thursday = "";
var friday = "";

class Availability_Controller {

    constructor() {

    }

    main() {
        setup_pixi_stage(1000, 700, 0x000000);

        app.stage.addChild(new Availability());
    }
}

class Availability extends PIXI.Graphics {

    constructor() {
        super();

        this.draw_days();
        this.x = 200;
        this.y = 200;
    }

    /**
     * Draws timeslots for each day
     * */
    draw_days() {

        this.lineStyle(1, color);
        this.beginFill(color);
        this.drawCircle(0, 0, radius);
        this.endFill();
    }

    /**
     * Draws the timeslots for one day
     * */
    draw_day() {

    }

    
}


function retrieveData(monday, tuesday, wednesday, thursday, friday) {

    this.monday = monday;
    this.tuesday = tuesday;
    this.wednesday = wednesday;
    this.thursday = thursday;
    this.friday = friday;
}
