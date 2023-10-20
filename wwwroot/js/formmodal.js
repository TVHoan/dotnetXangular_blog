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
var OnResult = (data) => { };
var OnError = (XMLHttpRequest, textStatus, errorThrown) => { };
$("#submitform").on('click', function (e) {
    e.preventDefault();
    if ($("#modalform  form").valid()) {
/*        $("#modalform  form").trigger("submit")
*/       var url = $("#modalform  form").attr("action")
        var formdata = new FormData()
        const datainform = $("#modalform  form").serializeArray();
        for (let index = 0; index < datainform.length; index++) {
            let name = datainform[index].name
            let value = $("#modal-form").find(`[name=${'"' + name + '"'}]`).val()
            formdata.append(name, value)
        }
       var dataType = "json"
        if ($("#modalform  form").attr("enctype") != undefined) {
            dataType = $("#modalform  form").attr("enctype")
        }
        $.ajax({
            type: "POST",
            url: url,
            data: new FormData($("#modalform  form")[0]),
           enctype: 'multipart/form-data',
            processData: false,  // Important!
            contentType: false,
            dataType: "JSON",
            headers: {
                RequestVerificationToken:
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },

            success: function (data) {
                $('#modalform').modal('hide');
                $(".modal-backdrop").toggle("show")
                OnResult(data)
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                OnError(XMLHttpRequest, textStatus, errorThrown)
            }
            
        });
       
    }
    
})

