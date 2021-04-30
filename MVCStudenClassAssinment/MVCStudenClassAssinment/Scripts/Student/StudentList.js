
var StudentList = {
    Init: function () {
        this.RegisterEvent();
    },

    RegisterEvent: function () {
        $("input:checkbox").off("click").on("click", this.UpdateButton);
        $("#submitButtton").off("click").on("click", this.SubmitActiveStatus);
    },

    UpdateButton: function () {
        $("input:checkbox:checked").length > 0 ? $("#submitButtton").removeAttr("disabled") : $("#submitButtton").attr("disabled", "disabled");
    },

    SubmitActiveStatus: function () {
        var studentStatus = StudentList.GetActiveStatusStudentId();
        $.ajax({
            url: 'Student/UpdateStudentStatus',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(studentStatus) ,
            type: 'POST',
            success: function (data) {
                //$.connection.hub.log("ClearWebsiteCachePurgeStatus : " + JSON.stringify(data));
            },
            error: function () {
                //jAlert('error', AdminLocalization.AJAX_FAILED_ERROR_MSG, "Error");
            }
        });
    },

    GetActiveStatusStudentId: function () {
        var selectedStudentIds = [];
        $.each($("input:checkbox"), function () {
            selectedStudentIds.push(
                {
                    studentid: $(this).attr('value-studentid'),
                    status: $(this).val()
                }               
            )
        });
        return selectedStudentIds;
    }



};
