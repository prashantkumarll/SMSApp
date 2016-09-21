﻿$(function () {

    $('#btnSubmit').on('click', function () {
        var skillname = $('#Skills option:selected').text();
        var rating = $('#Ratings option:selected').text();
        if (ValidateSkills(skillname, rating)) {
            if ((skillname !== "Select a value" || rating !== "Select a value")) {
                $.ajax({
                    type: "POST",
                    url: "/Employee/AddSkills",
                    data: { skillname: skillname, rating: rating },
                    dataType: "json",
                    success: function (data) {

                        if (data !== "Already Exists") {

                            var tbl = $("#tblContent").append("<tr>" +
                                    "<td>" + data["SkillName"] + "</td>" +
                                    "<td>" + data["Rating"] + "</td>" + "<td>" + "<input type='button' class='btn btn-danger' id='btnDelete' value='Delete' />" + "</td>" +
                                    "<td>" + "<input type='hidden' value=" + data["Id"] + " " + "id='hdnId' class='ids' />" + "</td>" +
                                    "</tr>");
                            $('#lblMessage').text("Skills Added successfully.");
                            $('#lblMessage').css({ color: "green" });

                        }
                        else {
                            $('#lblMessage').text(data);
                            $('#lblMessage').css({ color: "orange" });
                        }
                    },
                    error: function () {
                    }
                });
            }
        }
        else {
            $('#lblMessage').text("Please select a valid skill.");
            $('#lblMessage').css({ color: "orange" });
            return;
        }
    });    

    function RemoveSkill() {
        var skillid = $('#hdnId').val();
        var row = $(this).parent();
        var skillname = $('#Skills option:selected').text();
        $.ajax({
            type: "POST",
            url: "/Employee/DeleteSkill",
            data: { id: skillid },
            dataType: "json",
            success: function () {
                window.location.reload();
            },
            error: function () { }
        })
    }

    function ValidateSkills(skillname, rating) {
        var status = true;
        if (skillname === "Select a value" && rating !== "Select a value") {
            $('#lblMessage').text("Please select a valid skill.");
            $('#lblMessage').css({ color: "orange" });
            status = false;
            return status;
        }
        if (skillname !== "Select a value" && rating === "Select a value") {
            $('#lblMessage').text("Please select a valid skill.");
            $('#lblMessage').css({ color: "orange" });
            status = false;
            return status;
        }
        return status;
    }

    $('#tblContent').on('click', '#btnDelete', function () {
        var tr = $(this).closest('tr');
        var skillid = tr.find('.ids').val();
        $.ajax({
            type: "POST",
            url: "/Employee/DeleteSkill",
            data: { id: skillid },
            dataType: "json",
            success: function () {
                tr.remove();
                $('#lblMessage').text("Skills Deleted successfully.");
                $('#lblMessage').css({ color: "red" });
            },
            error: function () { }
        })
    });

})
