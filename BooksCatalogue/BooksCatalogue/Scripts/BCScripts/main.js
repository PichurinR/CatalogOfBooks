var oTable = $('#myDatatable').DataTable({
    "ajax": {
        "url": '/book/GetBooks',
        "type": "get",
        "datatype": "json"
    },
    "columns": [
        { "data": "Title", "autoWidth": true },
        { "data": "Pages", "autoWidth": true },
        { "data": "DateOfPublication", "autoWidth": true },
        { "data": "Rating", "autoWidth": true },
        {
            "data": "Authors", "autoWidth": true, "render": function (data) {
                var res = "";
                for (var i = 0; i < data.length; i++) {
                    var item = data[i];
                    res += '<a class="popup" href="/author/Edit/' + item.Id + '">' + item.FirstName + " " + item.LastName + '</a>'
                    res += "  ";
                }
                return res;
            }
        },
        {
            "data": "Id", "width": "50px", "render": function (data) {
                return '<a class="popup" href="/book/Edit/' + data + '">Edit</a>';
            }
        },
        {
            "data": "Id", "width": "50px", "render": function (data) {
                return '<a class="popup" href="/book/delete/' + data + '">Delete</a>';
            }
        }
    ]
});
$('.tablecontainer').on('click',
    'a.popup',
    function (e) {
        e.preventDefault();
        OpenPopup($(this).attr('href'));
    });
function OpenPopup(pageUrl) {
    var $pageContent = $('<div/>');
    $pageContent.load(pageUrl, function () {
        $('#popupForm', $pageContent).removeData('validator');
        $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse('form');

    });

    $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
        .html($pageContent)
        .dialog({
            draggable: false,
            autoOpen: false,
            resizable: false,
            model: true,
            title: 'Popup Dialog',
            height: 550,
            width: 600,
            close: function () {
                $dialog.dialog('destroy').remove();
            }
        })

    $('.popupWindow').on('submit',
        '#popupForm',
        function (e) {
            var url = $('#popupForm')[0].action;
            $.ajax({
                type: "POST",
                url: url,
                data: $('#popupForm').serialize(),
                success: function (data) {
                    if (data.status) {
                        $dialog.dialog('close');
                        oTable.ajax.reload();
                    }
                }
            });

            e.preventDefault();
        });
    $dialog.dialog('open');
}
