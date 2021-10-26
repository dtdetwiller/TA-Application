// JavaScript for the admin page.

function saveNote(elementID, courseID)
{
    var URL = "/Courses/SaveNote";
    var value = document.getElementById(elementID).value;

    var data =
    {
        elementID: elementID,
        courseID: courseID,
        value: value
    };

    $.post(URL, data)
        .done(function () {
                       
        })
        .fail(function () {

        })
}