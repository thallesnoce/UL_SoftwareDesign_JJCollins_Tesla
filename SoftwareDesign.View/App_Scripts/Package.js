var Package;
(function (Package) {
    var BuyPackageController = /** @class */ (function () {
        function BuyPackageController(packageId) {
            this.packageId = packageId;
            this.selectedServices = "";
            this.bindCalculatePrice();
            this.bindBuyPackage();
            this.bindServices();
        }
        BuyPackageController.prototype.bindServices = function () {
            $("#js-serviceOption").kendoMultiSelect({
                placeholder: "Select Additional Service...",
                dataSource: [
                    { Name: "Honey Moon + 800.00", Id: 1 },
                    { Name: "Bachelor Party Holiday + 1000.00", Id: 2 },
                    { Name: "BirthDay Party + 100", Id: 3 }
                ],
                dataTextField: "Name",
                dataValueField: "Id"
            });
        };
        BuyPackageController.prototype.bindCalculatePrice = function () {
            var _this = this;
            var url = '/Package/CalculatePrice';
            $("#js-btnBuyPackage").click(function () {
                var $buttonClicked = $(_this);
                var id = $buttonClicked.attr('data-id');
                var options = { "backdrop": "static", keyboard: true };
                var servicesKendo = $("#js-serviceOption").data("kendoMultiSelect").value();
                var services = servicesKendo.join(",");
                var request = {
                    packageId: _this.packageId,
                    additionalServices: services
                };
                $.get(url, request, function (data) {
                    $('#myModalContent').html(data);
                    $('#myModal').modal(options);
                    $('#myModal').modal('show');
                    _this.bindBuyPackage();
                });
            });
            $("#closbtn").click(function () {
                $("#myModal").modal('hide');
            });
        };
        BuyPackageController.prototype.bindBuyPackage = function () {
            var _this = this;
            var url = '/Package/BuyPackage';
            $("#btnBuy").click(function () {
                var $buttonClicked = $(_this);
                var id = $buttonClicked.attr('data-id');
                var options = { "backdrop": "static", keyboard: true };
                var request = {
                    packageId: $("#PackageId").val(),
                    price: $("#Price").val(),
                    cardOptions: $("#cardNumber").val(),
                    cardNumber: $("#cardNumber").val(),
                    expirationDate: $("#expirationDate").val(),
                    cvc: $("#cvc").val()
                };
                $.get(url, request, function (data) {
                    $('#myModalContent').html(data);
                    $('#myModal').modal(options);
                    $('#myModal').modal('show');
                });
            });
            $("#closbtn").click(function () {
                $("#myModal").modal('hide');
            });
        };
        return BuyPackageController;
    }());
    Package.BuyPackageController = BuyPackageController;
})(Package || (Package = {}));
//# sourceMappingURL=Package.js.map