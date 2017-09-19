//JavaScript for Reviews

function ListSortedReviewsScript() {

    var selectValue = $("#SelectOptionInput").val();
    var descendingValue = $("#DescendingInput").prop("checked");

    $.ajax({
        type: 'GET',
        url: '/Reviews/AjaxListReviews',
        data: {
            sortBy: selectValue,
            isDescending: descendingValue
        }
    })
        .done(function (result) {
            $("#outputResult").html(result);
            $("#currentlySortedBy").text("Sorted by: " + selectValue);
            $("#defaultResult").remove();
        })

        .fail(function (xhr, status, error) {
            $("#outputResult").text("No matches where found.");
        });
}

