ClassicEditor
    .create(document.querySelector('#editor'), {
        ckfinder: {
            uploadUrl: '/api/uploadfile'
        }
    })
    .then(editor => {
        editor.model.document.on('change:data', (evt, data) => {
            $('#editor').html(editor.getData());
        });
    })
    .catch(error => {
        console.error(error);
    });