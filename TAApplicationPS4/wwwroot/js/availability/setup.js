/**
 * Author:    Daniel Detwiller
 * Partner:   None
 * Date:      11-22-2021
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Daniel Detwiller - This work may not be copied for use in Academic Coursework.
 *
 * I, Daniel Detwiller, certify that I wrote this code from scratch and did
 * not copy it in part or whole from another source.  Any references used
 * in the completion of the assignment are cited in my README file and in
 * the appropriate method header.
 *
 * File Contents
 *
 *      This is the javascipt file that sets up the PIXI canvas
 */

/**
 * Global access to the PIXI Application 
 */
var app = null;

/**
 *  Create PIXI stage
 */
function setup_pixi_stage(width, height) {
    app = new PIXI.Application({ backgroundColor: 0xffffff });
    app.renderer.resize(width, height);
    $("#canvas_div").append(app.view);
}