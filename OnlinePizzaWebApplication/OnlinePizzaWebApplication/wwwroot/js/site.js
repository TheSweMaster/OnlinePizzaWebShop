// Write your Javascript code.

function listSearchExamplesScript() {

    var value = $("#SearchFieldId").val();

    $.ajax({
        type: 'GET',
        url: '/Pizzas/AjaxSearchList',
        data: { searchString: value }
    })
        .done(function (result) {
            $("#SuggestOutput").html(result);
            $("#PizzaSummaryId").remove();
        })

        .fail(function (xhr, status, error) {
            $("#SuggestOutput").text("No matches where found.");
        });
}

$.ajax({
    type: 'POST',
    url: 'PageName.aspx/GetDate',
    data: '{ }',
    contentType: 'application/json; charset=utf-8',
    dataType: 'json',
    success: function (msg) {
        // Do something interesting here.
    }
});

$("button").click(function () {
    $.ajax({
        url: "demo_test.txt", success: function (result) {
            $("#div1").html(result);
        }
    });
});

$(document).ready(function () {
    // Add the page method call as an onclick handler for the div.
    $("#Result").click(function () {
        $.ajax({
            type: "POST",
            url: "Default.aspx/GetDate",
            data: { someParameter: "some value" },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                // Replace the div's content with the page method's return.
                $("#Result").text(msg.d);
            }
        });
    });
});
