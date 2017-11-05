var Package;
(function (Package) {
    var BuyPackageController = /** @class */ (function () {
        function BuyPackageController() {
            this.bindCalculatePrice();
            this.bindBuyPackage();
        }
        BuyPackageController.prototype.bindCalculatePrice = function () {
            var _this = this;
            var url = '/Package/CalculatePrice';
            $("#btnBuyPackage").click(function () {
                var $buttonClicked = $(_this);
                var id = $buttonClicked.attr('data-id');
                var options = { "backdrop": "static", keyboard: true };
                var request = {
                    packageId: 1,
                    additionalServices: "1,2"
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
                debugger;
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