function Pet(data) {
    this.Id     = ko.observable(data.ID);
    this.Name   = ko.observable(data.Name);
    this.Breed  = ko.observable(data.Breed);
    this.Weight = ko.observable(data.Weight);
    this.Bowls  = ko.observableArray(data.BowlPet);
}

function PetViewModel() {
    var self = this;

    self.pets           = ko.observableArray([]);
    self.isLoading      = ko.observable(false);
    self.pet            = ko.observable();

    self.createName     = ko.observable("");
    self.createBreed    = ko.observable("");
    self.createWeight   = ko.observable(0.00);

    


    self.getPetLoad = function () {
        var id = self.Id;
        self.getPet(id());
    }


    self.Id = ko.computed(function () {
        var uri = document.URL;
        return uri.substring(uri.lastIndexOf('/') + 1);
    });


    self.getPet = function (id) {
        self.isLoading(true);
        $.getJSON('/api/pet/' + id)
            .success(function (allData) {
                self.pet(new Pet(allData));
                self.isLoading(false);
                document.write(ko.toJSON(allData));
            })
            .always(function () {
                self.isLoading(false);
            })

    }

    self.getPets = function () {
        self.isLoading(true);
        $.getJSON('/api/pet')
            .success(function (allData) {
                var mappedPets = $.map(allData, function (item) {
                    return new Pet(item);
                });
                self.pets(mappedPets);
                self.isLoading(false);
            })
    }


    self.deletePet = function (id) {
        $.ajax({
            url: '/api/pet/' + id,
            type: "DELETE",
            success: function (result) {
                window.location = '../';
            }
        });
    };

    self.createPet = function () {
        var data = {
            ID : null,
            Name: self.createName(),
            Breed: self.createBreed(),
            Weight: self.createWeight(),
            BowlPet: null

        }
        var p = new Pet(data);

        var helper = ko.toJS(p);
        delete helper.Id;
        
        $.ajax({
            url: '/api/pet',
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

