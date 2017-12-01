module Package {

    export class BuyPackageController {
        private selectedServices: string = "";
        constructor(private packageId: Number) {
            this.bindCalculatePrice();
            this.bindBuyPackage();
            this.bindServices();
        }

        bindServices() {
            debugger;
            $("js-btnAddService").click(() => {
                debugger;
                var selectService = $("js-serviceOption").val;
                this.selectedServices = `${selectService}`;
            });
        }

        bindCalculatePrice() {
            var url = '/Package/CalculatePrice';

            $("#js-btnBuyPackage").click(() => {
                var $buttonClicked = $(this);
                var id = $buttonClicked.attr('data-id');
                var options = { "backdrop": "static", keyboard: true };
                var request = {
                    packageId: this.packageId,
                    additionalServices: "1,2"
                };

                $.get(url, request, (data) => {
                    $('#myModalContent').html(data);
                    $('#myModal').modal(options);
                    $('#myModal').modal('show');
                    this.bindBuyPackage();
                });
            });

            $("#closbtn").click(() => {
                $("#myModal").modal('hide');
            });
        }

        bindBuyPackage() {
            var url = '/Package/BuyPackage';

            $("#btnBuy").click(() => {
                var $buttonClicked = $(this);
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

                $.get(url, request, (data) => {
                    $('#myModalContent').html(data);
                    $('#myModal').modal(options);
                    $('#myModal').modal('show');
                });
            });

            $("#closbtn").click(() => {
                $("#myModal").modal('hide');
            });
        }
    }
}