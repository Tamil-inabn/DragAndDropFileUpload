// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var dropArea = $('#dropArea');

    dropArea.on('dragover', function (e) {
        e.preventDefault();
        dropArea.css('background-color', '#f5f5f5');
    });

    dropArea.on('dragleave', function () {
        dropArea.css('background-color', '');
    });

    dropArea.on('drop', function (e) {
        e.preventDefault();
        dropArea.css('background-color', '');

        var files = e.originalEvent.dataTransfer.files;
        console.log(files);
        handleFileUpload(files);
    });

    $('#dropArea').on("click", function (e) {
        e.preventDefault();
        var fileDialog = $('<input type="file">');
        fileDialog.click();
        fileDialog.change(function (e) {
            var geekss = e.target.files;
            console.log(geekss);
            handleFileUpload(geekss);
        });
    });
});

function handleFileUpload(files) {
    var formData = new FormData();
    formData.append('files', files[0]);

    $.ajax({
        url: '/Home/UploadFile',
        type: 'POST',
        data: formData,
        contentType: false,
        processData: false,
        success: function (result) {
            alert(result.message);
        },
        error: function () {
            alert('Error uploading files.');
        }
    });
}
