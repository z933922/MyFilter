define(function () {

    function dd(id){
        require(['jquery'], function ($) {
           return  $("#" + id);
    });
    }
    return dd;
});