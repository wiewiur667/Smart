function Bowl(data) {
    this.Id             = ko.observable(data.ID);
    this.Name           = ko.observable(data.Name);
    this.Location       = ko.observable(data.Location);
    this.FoodName       = ko.observable(data.FoodName);
    this.AlertAmount    = ko.observable(data.AlertAmount);
    this.FoodAmount     = ko.observable(data.FoodAmount);
    this.Pets           = ko.observable(data.BowlPet);
    this.Dispensing     = ko.observable(false);
    this.Locked         = ko.observable(false);
}

function BowlViewModel() {
    var self = this;

    self.bowls              = ko.observableArray([]);
    self.bowl               = ko.observable();
    self.isLoading          = ko.observable(false);

    self.createName         = ko.observable();
    self.createLocation     = ko.observable();
    self.createFoodName     = ko.observable();
    self.createFoodAmount   = ko.observable();
    self.createAlertAmount  = ko.observable();


    

    self.getBowlLoad = function () {
        var id = self.Id;
        self.getBowl(id());
    }

    self.Id = ko.computed(function () {
        var uri = document.URL;
        return uri.substring(uri.lastIndexOf('/') + 1);
    });

    self.getBowls = function () {
        self.isLoading(true);
        $.getJSON('/api/bowl')
            .success(function (allData) {

                var mappedBowls = $.map(allData, function (item) {
                    return new Bowl(item);
                });
                self.bowls(mappedBowls);
                self.isLoading(false);
            })
    }

    self.getBowl = function (id) {
        self.isLoading(true);
        $.getJSON('/api/bowl/' + id)
            .success(function (allData) {
                self.bowl(new Bowl(allData));
                self.isLoading(false);
            })
            .always(function () {
                self.isLoading(false);
            })
            .error(function() {
                alert("error");
            })
        
    }

    self.deleteBowl = function (id) {
        $.ajax({
            url: '/api/bowl/' + id,
            type: "DELETE",
            success: function (result) {
                window.location = '../';
            }
        });
    };

    self.createBowl = function () {
        var data = {
            ID: null,
            Name: self.createName(),
            Location: self.createLocation(),
            FoodName: self.createFoodName(),
            FoodAmount: self.createFoodAmount(),
            AlertAmount: self. createAlertAmount(),
            BowlPet: null

        }
        var p = new Bowl(data);

        var helper = ko.toJS(p);
        delete helper.Id;
        delete helper.Pets;

        $.ajax({
            url: '/api/bowl',
            type: "POST",
            data: ko.toJSON(helper),
            contentType: "application/json",
            success: function () {
                window.location = './';
            },
            error: function (a, b, c) {
                alert(c);
            }
        });
    }
}

