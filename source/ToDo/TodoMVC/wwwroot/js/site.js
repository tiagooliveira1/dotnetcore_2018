// Write your JavaScript code.


$(document).ready(function()  {
    $('#add-item-button')
        .on('click', addItems)
});

function addItems() {
    $('#add-item-error').hide();
    var newTitle = $('#add-item-title').val();

    var data = {title: newTitle};
    $.post('Todo/addItem', data, function() {
        window.location = '/Todo';
    })
    .fail(function (data) {
        if (data && data.reponseJSON) {
            var key = Object
            .keys(data.responseJSON[0])
            var firstError = data
                .reponseJSON[key];
            $('#add-item-error')
                .text(firstError)
                .show();
        }
    })
}