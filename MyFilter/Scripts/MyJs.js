﻿$(function () {
    $.fn.extend(($,jQuery),{

    })
    $.fn.Isuser = function () {
        var value = $(this).val();
        if (value.length<4) {
            alert("请输入正确的用户名");
            return false;
        }
        return true;
    }

    $.extend({
        Isok: function () {
            alert("这是个扩展方法了");
        }
    });
})