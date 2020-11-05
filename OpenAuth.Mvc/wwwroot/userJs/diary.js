layui.config({
    base: "/js/"
}).use(['form', 'vue', 'ztree', 'layer', 'jquery', 'table', 'droptree', 'openauth', 'iconPicker', 'utils'], function () {
    var form = layui.form,
        layer = layui.layer,
        $ = layui.jquery;
    var iconPicker = layui.iconPicker;
    var btnIconPicker = layui.iconPicker;
    iconPicker.render({
        // 选择器，推荐使用input
        elem: '#IconName',
        type: 'fontClass',
        // 每个图标格子的宽度：'43px'或'20%'
        cellWidth: '43px',
    });
    btnIconPicker.render({   //按钮的图标
        // 选择器，推荐使用input
        elem: '#Icon',
        type: 'fontClass',
        // 每个图标格子的宽度：'43px'或'20%'
        cellWidth: '43px',
    });

    var data = { type: true };
    //提交数据
    form.on('submit(openSub)',
        function () {
            data.type = true;
            $.post('/Diary/Open', data,
                function (data) {
                    layer.msg(data.Message);
                },
                "json");
            return false;
        });
    form.on('submit(closeSub)',
        function () {
            data.type = false;
            $.post('/Diary/Open', data,
                function (data) {
                    layer.msg(data.Message);
                },
                "json");
            return false;
        });

    //行情接口通用域名
    //push2.eastmoney.com/api/qt/ulist.np/get?fields=f12,f13,f14,f2,f1,f3,f152&invt=2&ut=fa5fd1943c7b386f172d6893dbfba10b
    var _url = "http://51.push2.eastmoney.com/api/qt/stock/sse?ut=fa5fd1943c7b386f172d6893dbfba10b&fltt=2&fields=f120,f121,f122,f174,f175,f59,f163,f43,f57,f58,f169,f170,f46,f44,f51,f168,f47,f164,f116,f60,f45,f52,f50,f48,f167,f117,f71,f161,f49,f530,f135,f136,f137,f138,f139,f141,f142,f144,f145,f147,f148,f140,f143,f146,f149,f55,f62,f162,f92,f173,f104,f105,f84,f85,f183,f184,f185,f186,f187,f188,f189,f190,f191,f192,f107,f111,f86,f177,f78,f110,f262,f263,f264,f267,f268,f255,f256,f257,f258,f127,f199,f128,f198,f259,f260,f261,f171,f277,f278,f279,f288,f152,f250,f251,f252,f253,f254,f269,f270,f271,f272,f273,f274,f275,f276,f265,f266,f289,f290,f294,f295&secid=1.600764";
    $.ajax({
        url: _url,
        scriptCharset: "utf-8",
        dataType: "jsonp",
        jsonp: "cb",
        success: function (json) {
            console.log(json);
        }
    });
})

//添加百分号
function addPercent(vs) {
    var num = parseFloat(vs), item;
    if (num == 0) {
        item = num.toFixed(2) + "%"
    } else if (num) {
        var abs = Math.abs(num);
        if (abs >= 1000) { //大于10倍的用倍来表示 1000%
            item = (num / 100).toFixed(2) + "倍"
        } else {
            item = num.toFixed(2) + "%";
        }
    } else {
        item = vs;
    }
    return item
}