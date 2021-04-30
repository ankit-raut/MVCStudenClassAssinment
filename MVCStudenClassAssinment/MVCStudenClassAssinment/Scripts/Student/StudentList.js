
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
            data: JSON.stringify(studentStatus),
            type: 'POST',
            success: function (data) {
                if (data.IsSuccess) {
                    StudentList.ToastMessage("success","Successfully Updated !")
                }
                else {
                    StudentList.ToastMessage("error", "Not Updated !")
                }
            },
            error: function () {
                StudentList.ToastMessage("error", "Not Updated !")
            }
        });
    },
    ToastMessage: function (type,message) {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr[type](message)
    },
    GetActiveStatusStudentId: function () {
        var selectedStudentIds = [];
        $.each($("input:checkbox"), function () {
            selectedStudentIds.push(
                {
                    studentid: $(this).attr('value-studentid'),
                    status: this.checked ? this.value : "false"
                }
            )
        });
        return selectedStudentIds;
    }



};
