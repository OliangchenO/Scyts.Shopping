$.extend($.fn.datagrid.defaults.editors, {
    uploadBtn: {//datetimebox就是你要自定义editor的名称
        init: function (container, options) {
            var input = $(' <input  onclick="uploadImg(this)">').appendTo(container);
            return input;
        },
        getValue: function (target) {

            return $(target).val();
        },
        setValue: function (target, value) {
           
            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    }
});


$.extend($.fn.datagrid.defaults.editors, {
    ContentBtn: {//datetimebox就是你要自定义editor的名称
        init: function (container, options) {
            var input = $(' <input  onclick="setcontent(this)">').appendTo(container);
            return input;
        },
        getValue: function (target) {

            return $(target).val();
        },
        setValue: function (target, value) {

            $(target).val(value);
        },
        resize: function (target, width) {
            var input = $(target);
            if ($.boxModel == true) {
                input.width(width - (input.outerWidth() - input.width()));
            } else {
                input.width(width);
            }
        }
    }
});