module Package {

    export class BuyPackageController {
        private selectedServices: string = "";
        constructor(private packageId: Number) {
            this.bindCalculatePrice();
            this.bindBuyPackage();
            this.bindServices();
        }

        bindServices() {

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
        }

        bindCalculatePrice() {
            var url = '/Package/CalculatePrice';

            $("#js-btnBuyPackage").click(() => {
                var $buttonClicked = $(this);
                var id = $buttonClicked.attr('data-id');
                var options = { "backdrop": "static", keyboard: true };

                var servicesKendo: Array<number> = $("#js-serviceOption").data("kendoMultiSelect").value();
                var services = servicesKendo.join(",");

                var request = {
                    packageId: this.packageId,
                    additionalServices: services
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