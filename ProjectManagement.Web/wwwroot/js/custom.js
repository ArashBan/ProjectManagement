$(document).ready(function () {
    var editors = $("[ckeditor]");
    if (editors.length > 0) {
        $.getScript('/js/ckeditor.js', function () {
            $(editors).each(function (index, value) {
                var id = $(value).attr('ckeditor');
                ClassicEditor.create(document.querySelector('[ckeditor="' + id + '"]'),
                    {
                        toolbar: {
                            items: [
                                'heading',
                                '|',
                                'bold',
                                'italic',
                                'link',
                                '|',
                                'fontSize',
                                'fontColor',
                                '|',
                                'blockQuote',
                                'insertTable',
                                'undo',
                                'redo',
                                'codeBlock'
                            ]
                        },
                        language: 'fa',
                        table: {
                            contentToolbar: [
                                'tableColumn',
                                'tableRow',
                                'mergeTableCells'
                            ]
                        },
                        licenseKey: '',
                        simpleUpload: {
                            // The URL that the images are uploaded to.
                            uploadUrl: '/Uploader/UploadImage'
                        },
                        fontColor: {
                            colors: [
                                {
                                    color: 'hsl(0, 0%, 0%)',
                                    label: 'Black'                                    
                                }
                            ]
                        },
                        fontBackgroundColor: {
                            columns: 6,
                        },
                    })
                    .then(editor => {
                        window.editor = editor;
                    }).catch(err => {
                        console.error(err);
                    });
            });
        });
    }
});

function open_waiting(selector = 'body') {
    $(selector).waitMe({
        effect: 'win8',
        text: 'لطفا صبر کنید ...',
        bg: 'rgba(21, 21, 33,0.7)',
        color: 'white'
    });
}

function close_waiting(selector = 'body') {
    $(selector).waitMe('hide');
}