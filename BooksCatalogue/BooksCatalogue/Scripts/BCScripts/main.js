var MainJS = MainJS || {};
(function () {
    var self = this;

    const addBtnId = '#addBtn';
    const bookModalId = '#bookModal';
    var createBookUrl;
            
    self.Initialize = function (getUrl, createUrl) {
              

        $(addBtnId).off().on("click", ShowModal);
        createBookUrl = createUrl;
        InitializeDataTable(getUrl);
    };

    var ShowModal = function (createUrl) {
        $(bookModalId).modal('show');
        Book.Initialize(createBookUrl);
        $('#dateOfPublication').datepicker({
            format: 'yyyy-MM-dd 00:00:00 a'
        });

    };


    var InitializeDataTable = function(url) {
        var oTable = $('#myDatatable').DataTable({
            "ajax": {
                "url": url,
                "type": "get",
                "datatype": "json"
            },
            "columns": [
                { "data": "Title", "autoWidth": true },
                { "data": "Pages", "autoWidth": true },
                {
                    "data": "DateOfPublication",
                    "autoWidth": true,
                    "render": function(data) {
                        return moment(data).format('YYYY/MM');
                    }

                },
                { "data": "Rating", "autoWidth": true },
                {
                    "data": "Authors",
                    "autoWidth": true,
                    "render": function(data) {
                        var res = "";
                        for (var i = 0; i < data.length; i++) {
                            var item = data[i];
                            res += '<a class="popup" href="/author/Edit/' +
                                item.Id +
                                '">' +
                                item.FirstName +
                                " " +
                                item.LastName +
                                '</a>'
                            res += "  ";
                        }
                        return res;
                    }
                },
                {
                    "data": "Id",
                    "width": "50px",
                    "render": function(data) {
                        return '<a class="popup" href="/book/Edit/' + data + '">Edit</a>';
                    }
                },
                {
                    "data": "Id",
                    "width": "50px",
                    "render": function(data) {
                        return '<a class="popup" href="/book/delete/' + data + '">Delete</a>';
                    }
                }
            ]
        });
    };
}).apply(MainJS);