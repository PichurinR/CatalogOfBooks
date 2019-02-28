var Book = Book || {};
(function () {
    var self = this;
    const  saveBtnId = '#save_btn';

    const options = [{
        id: '1',
        text: 'value1'
    }, {
        id: '2',
        text: 'value2'
    }, {
        text: 'daddy',
        children: [{
            id: '3',
            text: 'child1'
        }]
    }];

    self.Id = ko.observable("");
    self.Title = ko.observable("");
    self.Pages = ko.observable("");
    self.DateOfPublication = ko.observable("");
    self.Rating = ko.observable("");
    self.obsOptions = ko.observableArray(options);
    self.AuthorIds = ko.observableArray();
    self.value = ko.observable();
   
    var BookVM = {
        Id: self.Id,
        Title: self.Title,
        Pages: self.Pages,
        DateOfPublication: self.DateOfPublication,
        AuthorIds: self.AuthorIds,
        Rating: self.Rating,
        value: self.value,
        options: self.obsOptions
    };

    self.Initialize = function (createBookUrl) {

        self.createBookUrl = createBookUrl;
        ko.applyBindings(BookVM);

        $(saveBtnId).off().on("click", self.Create);
    };
    //Кастом біндінг для селект2+накаут
    ko.bindingHandlers.select2Options = {
        update: (element, valueAccessor, allBindingsAccessor, viewModel) => {
            var allBindings = allBindingsAccessor();

            $(element).select2("destroy");
            $(element).html("<option></option>");

         
            $(element).select2({
                "data": ko.utils.unwrapObservable(valueAccessor())
            });
        }
    };


    ko.bindingHandlers.select2 = {
        init: (element, valueAccessor, allBindingsAccessor, viewModel) => {
        
            ko.utils.domNodeDisposal.addDisposeCallback(element, () => {
                $(element).select2('destroy');
            });

            $(element).select2();
        },
        update: (element, valueAccessor, allBindingsAccessor, viewModel) => {
            var allBindings = allBindingsAccessor();

            if (allBindings["value"]) {
              
                const value = ko.utils.unwrapObservable(allBindings.value());
                $(element).val(value).trigger("change");
            } else if (allBindings["selectedOptions"]) {
             
                const value = ko.utils.unwrapObservable(allBindings.selectedOptions());
                $(element).val(value).trigger("change");
            }
        }
    };

   
    self.Create = function () {
   $.ajax({
            url: self.createBookUrl,
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


    
}).apply(Book);