$('#modalform').on('show.bs.modal', function (event) {
    var modal = $(this);
    var button = $(event.relatedTarget) // Button that triggered the modal
    var link = event.relatedTarget.dataset.link;
    var title = event.relatedTarget.dataset.title;
    modal.find('.modal-title').html(title)
    /*
                var recipient = button.data('whatever') // Extract info from data-* attributes
    */
    $.ajax({
        url: link,
        type: 'GET',
        success: function (data) {
            modal.find('.modal-body').html(data)

        },
        error: function (e) {
            console.log(e.message);
        }
    });
});
$("#submitform").on('click', function () {
    $("#modalform  form").trigger("submit")
})