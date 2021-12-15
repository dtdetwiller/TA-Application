// JavaScript for the admin page.

$(function ()
{
    $("#admin_table").DataTable();
})

function triggerSwal(userid, role, elementID)
{
    var URL = "/Admin/changeRole";
    var data =
    {
        userid: userid,
        role: role,
        elementID: elementID
    };

    Swal.fire({
        title: 'Change role?',
        text: "You are about to chenge the role of this user.",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, change it!'
    }).then((result) => {
        if (result.isConfirmed) {

            $.post("/Admin/changeRole", data)
                .done(function () {
                    Swal.fire(
                        'Role Changed!',
                        'The role of this user has been changed.',
                        'success'
                    )
                })
                .fail(function () {

                })

        }
        else {
            const toggleSwitch = document.getElementById(elementID);
            if (toggleSwitch.checked)
                toggleSwitch.checked = false;
            else
                toggleSwitch.checked = true;
        }
    })
}