$("#customerId").select2({
    theme: "bootstrap4",
    allowClear: true,
    ajax: {
        url: "/office/" + $("#officeId").val() + "/search/customers",
        contentType: "application/json; charset=utf-8",
        data: function (params) {
            var query =
                {
                    term: params.term,
                    officeId: $("#officeId").val()
                };
            return query;
        },        
        processResults: function (result) {            
            return {
                results: $.map(result, function (item) {
                    return {
                        id: item.id,
                        text: item.displayName
                    };
                }),
            };
        }
    }    
}).on('change', function () {    
    $("#customerId").val(this.value);
});

$("#vehicleId").select2({
    theme: "bootstrap4",
    allowClear: true,
    ajax: {
        url: function () {            
            return "/customer/" + $("#customerId").val() + "/search/vehicles"
        },
        contentType: "application/json; charset=utf-8",
        data: function (params) {
            var query =
                {
                    term: params.term
                };
            return query;
        },
        processResults: function (result) {
            return {
                results: $.map(result, function (item) {
                    return {
                        id: item.id,
                        text: item.displayName
                    };
                }),
            };
        }
    }
});