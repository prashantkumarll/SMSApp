function AddSkills()
{
    var skillname = $('#Skills option:selected').text();
    var rating = $('#Ratings option:selected').text();

    $.ajax({
            type: "POST",
            url: "/Employee/AddSkills",
            data: { skillname: skillname, rating: rating },            
            dataType: "json",
            success: function () { },
            error: function(){}
    })
}

function RemoveSkill()
{

    var skillid = $('#hdnId').val();    

    $.ajax({
        type: "POST",
        url: "/Employee/DeleteSkill",
        data: {id : skillid},
        dataType: "json",
        success: function () {
            this.remove();
        },
        error: function () { }
    })

}