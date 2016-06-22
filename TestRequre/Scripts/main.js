require.config({
    baseUrl: '/Scripts/',
    paths: {
        jquery: 'jquery-1.10.2',
        knockout: 'knockout-3.4.0'
    }
});

require(['jquery', 'knockout', 'Test'], function ($, ko, fun) {
    $("#mydiv").val("123123123123123");

    var mymodel = {
        ttname: ko.observable("你大爷的的"),
        ttname2: ko.observable("是你马屁的")
    };
    ko.applyBindings(mymodel, document.getElementById("div1"));

    ko.bindingHandlers.slideVisible = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            // Get the current value of the current property we're bound to
            
            var elDom = $(element);
            
        },
        update: function (element, valueaccessor, allbindingsaccessor, viewmodel) {
            var value = valueaccessor();
            console.log("value="+value);
            var allbinds = allbindingsaccessor();
            console.log("allbinds=" + allbinds);
            var valueunwrapped = ko.utils.unwrapObservable(value);

            var dd = ko.unwrap(value);
            var duration = allbinds.slideDuration || 400;
            //console.log(valueUnwrapped);
            if (valueunwrapped == true)
                $(element).slideDown(duration); // Make the element visible
           else
                $(element).slideUp(duration);

            var tt = valueaccessor();
            tt(true);
        }
    };

    var mmmodel = {
        giftWrap: ko.observable(true)
    };
    ko.applyBindings(mmmodel, document.getElementById("div2"));
    fun();
});


//require(['jquery', 'knockout'], function ($, ko) {

   
   
//});



