/*
 * Global variables
 */ 
let unselected_color = 0xB6EFFF;
let selected_color = 0xFFD2B6;

/*
 * Function to replace a character in a string at a index.
 */
String.prototype.replaceAt = function (index, replacement) {
    if (index >= this.length) {
        return this.valueOf();
    }

    return this.substring(0, index) + replacement + this.substring(index + 1);
}

/*
 * Represents a day column
 */
class Day extends PIXI.Graphics {

    slots = [];

    constructor(day, position, dayType) {
        super();

        for (let i = 0; i < 48; i++) {
            this.slots[i] = day.charAt(i);
        }

        this.interactive = true;
        
        this.draw_self(day, position);
    }

    draw_self(day, position) {
        
        for (let i = 0; i < String(day).length; i++) {

            if (String(day).charAt(i) == 'N') {
                let slot = new FifteenMinutes(unselected_color, position, 8 * (i + 1), i, false, this.slots);
                app.stage.addChild(slot);
            }
            else if (String(day).charAt(i) == 'Y'){
                let slot = new FifteenMinutes(selected_color, position, 8 * (i + 1), i, true, this.slots);
                app.stage.addChild(slot);
            }
        }
    }

    get get_slots() {
        let strSlots = this.slots.join("");
        return strSlots;
    }
}

// Flags for selecting and deselecting
var mouse_down = false;
var selecting = false;
var deselecting = false;

class FifteenMinutes extends PIXI.Graphics {

    #index = 0;
    #selected = false;
    #x_value = 0;
    #y_value = 0;
    slots = []

    constructor(color, x, y, i, select, slots) {

        super();
        this.interactive = true;
        this.#index = i;
        this.#selected = select;
        this.slots = slots;
       

        this.on('mousedown', this.pointer_down);
        this.on('mouseup', this.pointer_up);
        this.on('mouseover', this.pointer_over);

        this.draw_self(color, x, y);
    }

    draw_self(color, x, y) {
        this.beginFill(color);
        this.drawRect(x, y + 50, 80, 8);
        this.#x_value = x;
        this.#y_value = y + 50;
        this.endFill();
    }

    pointer_down() {
        this.clear();
        if (this.#selected) {
            deselecting = true;
            selecting = false;
            this.beginFill(unselected_color);
            this.#selected = false;
            this.slots[this.#index] = 'N';
        } else {
            selecting = true;
            deselecting = false;
            this.beginFill(selected_color);
            this.#selected = true;
            this.slots[this.#index] = 'Y';
        }

        this.drawRect(this.#x_value, this.#y_value, 80, 8);
        
        mouse_down = true;

        // Add the unsaved data message when edited.
        let savedText = new PIXI.Text('Unsaved data exists, make sure to click the Update Availability button to save.',
            { fontFamily: 'Arial', fontSize: 12, fill: 0xCD0000, align: 'center' });
        savedText.x = 60;
        savedText.y = 460;
        savedText.name = "savedText";
        app.stage.addChild(savedText);
    }

    pointer_up() {

        mouse_down = false;
    }

    pointer_over() {
        if (mouse_down && selecting) {
            this.clear();
            this.beginFill(selected_color);
            this.drawRect(this.#x_value, this.#y_value, 80, 8);
            this.#selected = true;
            this.slots[this.#index] = 'Y';
        }
        else if (mouse_down && deselecting) {
            this.clear();
            this.beginFill(unselected_color);
            this.drawRect(this.#x_value, this.#y_value, 80, 8);
            this.#selected = false;
            this.slots[this.#index] = 'N';
        }
    }
}

