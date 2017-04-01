
window.health = window.health || (function () {
    $('.special').hide();
    $('#optout').click(function () {
        $('.special').hide();
        $(this).prop('checked', true); // always selects it
        $('#planId').val(0);
        $('#title').val("No Plan Selected");
    });
    $('.healthplan').click(function () {
        var plan = $(this).attr('plan');
        var title = $(this).find('.plan-title').html();
        var id = $('#employeeId').val();
        if (id !== "") {
            $('.special').hide();
            $('#planId').val(plan);
            $('#title').val(title);
            $('#optout').prop('checked', false);
            $("div[plan='" + plan + "']").find('.special').fadeIn();
        }
    });
    $('#employeeTable tr').click(function(){
        var id = $(this).find(".employee-row-id").html();
        var cid = $('#employeeId').val();
        if (id === cid) {
            // show employee data
            $('#healthform').fadeIn();
        } else {
            // load employee data
            $('#healthform').fadeOut();
            $('#userId').val(id);
            $('#password').val('');
            $('#username').val('');
            $('#loginModal').modal('show');
        }
    });
    $("#loginform").submit(function (e) {

        //prevent default
        e.preventDefault();

        $('.special').hide();
        $('#employeeId').val('');
        $('#eName').val('');
        $('#title').val('');
        $('#optout').prop('checked', false);

        //get the action-url of the form
        //var actionurl = e.currentTarget.action;
        var actionurl = "/Home/RetrieveEmployee";

        //do request and handle the results
        $.ajax({
            url: actionurl,
            type: 'post',
            dataType: 'json',
            data: $("#loginform").serialize(),

            success: function (json) {
                //console.log(json);
                if (json.success) {
                    //console.log(json.employee);
                    $('#photo').attr('src', json.employee.PhotoUrl);
                    $('#employeeId').val(json.employee.Id);
                    $('#eName').val(json.employee.First + " " + json.employee.Last);
                    var plan = json.employee.BenefitPlanId || 0;
                    $('#title').val(json.employee.BenefitPlanTitle);
                    $('#planId').val(plan);
                    if (plan === 0) {
                        $('#optout').prop('checked', true);
                    } else {
                        $('#optout').prop('checked', false);
                        $("div[plan='" + plan + "']").find('.special').fadeIn();
                    }
                    $('#healthform').fadeIn();
                }
                $('#loginModal').modal('hide');
            },
            error: function (jqXhr, status, error) {
                console.log(status);
                console.log(error);
                console.log(jqXhr);
                $('#loginModal').modal('hide');
                alert("An error has occurred.");
            }
        });
    });
    $("#healthform").submit(function (e) {

        //prevent default
        e.preventDefault();

        if ($('#employeeId').val() === "") { return; }

        //get the action-url of the form
        var actionurl = "/Home/UpdatePlan";

        //do request and handle the results
        $.ajax({
            url: actionurl,
            type: 'post',
            dataType: 'json',
            data: $("#healthform").serialize(),

            success: function (data) {
                $('.alert-success').slideDown(1000);

                setTimeout(function () {
                    $('.alert-success').slideUp(1000);
                }, 3000);
            },
            error: function (jqXhr, status, error) {
                console.log(status);
                console.log(error);
                console.log(jqXhr);
                alert("An error has occurred.");
            }
        });
    });

    var pub = {
        findEmployee: function () {
            var id = $('#eid').val();
            if (id) {
                var uname = $('#username').val();
                //var password = 
            }
        }
    };
    return pub;
})();