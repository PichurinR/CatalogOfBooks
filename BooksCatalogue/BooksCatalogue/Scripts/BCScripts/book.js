var Book = Book || {};
(function () {
    var self = this;

    self.Id = ko.observable("");
    self.Title = ko.observable("");
    self.Pages = ko.observable("");
    self.DateOfPublication = ko.observable("");
    self.Rating = ko.observable("");
    self.AuthorIds = ko.observableArray();
   
    var BookVM = {
        Id: self.Id,
        Title: self.Title,
        Pages: self.Pages,
        DateOfPublication: self.DateOfPublication,
        AuthorIds: self.AuthorIds,
        Rating: self.Rating
    };

    self.create = function () {
        debugger;
        $.ajax({
            url: '@Url.Action("Create", "Book")',
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(Book),
            success: function(data) {
                alert("Book Id:" + data + "added!");
            }

        }).fail(
            function(xhr, textStatus, err) {
                alert(err);
            });
    };

 ko.applyBindings(BookVM);
    
}).apply(Book);