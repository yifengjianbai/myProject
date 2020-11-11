var onlinenum = 0;
var general = new Vue({
    methods: {
        //分页 页显示条数改变时
        handleSizeChange: function (val) {
            console.log(`每页 ${val} 条`);
            this.curr_pageSize = val;
            //this.getView();
        },
        //分页 当前定位页数改变时
        handleCurrentChange: function (val) {
            console.log(`当前页: ${val}`);
            this.curr_page = val;
            //this.getView();
        },
        //时间格式化
        formatTime: function (datetime) {
            var date = new Date(datetime);
            let o = {
                'y+': date.getFullYear(),
                'M+': date.getMonth() + 1,
                'd+': date.getDate(),
                'h+': date.getHours(),
                'm+': date.getMinutes(),
                's+': date.getSeconds()
            };
            for (var i = 1; i < o.length; i++) {
                if (o[i].length === 1) {
                    o[i] = '0' + o[i];
                }
            }
            if (o["M+"].toString().length === 1) {
                o["M+"] = '0' + o["M+"].toString();
            }
            if (o["d+"].toString().length === 1) {
                o["d+"] = '0' + o["d+"].toString();
            }
            if (o["h+"].toString().length === 1) {
                o["h+"] = '0' + o["h+"].toString();
            }
            if (o["m+"].toString().length === 1) {
                o["m+"] = '0' + o["m+"].toString();
            }
            if (o["s+"].toString().length === 1) {
                o["s+"] = '0' + o["s+"].toString();
            }
            return (o["y+"] + '-' + o["M+"] + '-' + o["d+"] + "\n" + o["h+"] + ':' + o["m+"] + ':' + o["s+"]);
        }
    }
});