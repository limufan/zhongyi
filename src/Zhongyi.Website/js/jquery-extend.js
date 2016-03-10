var anjianLeibie ={
    "民事诉讼代理": ["合同纠纷案件", "侵权纠纷案件", "婚姻家庭纠纷案件", "继承权纠纷案件", "劳动争议案件", "环境纠纷案件", "医疗纠纷案件", "其他"],
    "刑事诉讼辩护及代理": ["公诉案件辩护", "自诉案件辩护", "提供咨询,代为申诉、控告", "申请取保候审", "死刑案件辩护", "公诉案件附带民事诉讼代理", "自诉案件代理"],
    "行政诉讼代理": ["代理原告", "代理被告"],
    "仲裁业务": ["国内仲裁", "劳动仲裁", "涉外仲裁"],
    "法律顾问": ["政府法律顾问", "企业法律顾问", "事业单位法律顾问", "社会全体法律顾问", "公民个人法律顾问", "其他"],
    "非诉讼法律事务": ["知识产权", "房地产", "公司业务", "金融", "证券", "期货", "税务代理", "公平贸易", "保险", "破产、清算", "其他"],
    "咨询和代写法律文书": ["口头咨询", "书面咨询", "代写法律文书"],
    "提供法律援助情况": ["刑事诉讼法律援助", "民事诉讼法律援助", "行政诉讼法律援助", "非诉讼法律援助"],
    "参加公益事业和社会活动情况": ["义务法律咨询服务", "参加公益法律服务", "参加涉法信访", "参加义务法律咨询律师", "为公益事业捐款数", "为社会提供法律业务培训"]
}
jQuery.extend({
    bindAnjianYewuDalei: function(input){
        var daleiArray = [];
        daleiArray.push({text: "请选择", value: ""});
        for(var dalei in anjianLeibie){
            daleiArray.push(dalei);
        }
        input.setSource(daleiArray);
    },
    bindAnjianYewuXiaolei: function(input, dalei){
        var xiaoleiArray = []; 
        xiaoleiArray.push({text: "请选择", value: ""});
        if(anjianLeibie[dalei]){
            xiaoleiArray = xiaoleiArray.concat(anjianLeibie[dalei]);
        }
        input.setSource(xiaoleiArray);
    }
});
jQuery.extend({
    resolveUrl: function(path, param){
        var query = "";
        if(param){
            query = $.param(param);
        }
        if(path.indexOf("?") > -1){
            return $.baseUrl + path + query;
        }
        else{
            return $.baseUrl + path + "?" + query;
        }
    },
    setRequired: function(input, required){
        input.element
            .closest(".form-group")
            .find(".control-label span").remove();
        if (required) {
            input.element
                .closest(".form-group")
                .find(".control-label")
                .prepend("<span class='requiredSign'>*</span>");
        }
        input.setRequired(required);
    },
    getDateRange: function(fanwei){
        var dateRange = { };
        var today = new Date();
        var todayYear = today.getFullYear();
        var todayMonth = today.getMonth();
        var todayDate = today.getDate();
        var thisMonthDays = new Date(todayYear, todayMonth, 0).getDate() + 1;
        var dayOfWeek = today.getDay() ;
        if(fanwei == "bannian"){
            if (todayMonth < 6)
            {
                dateRange.start = new Date(todayYear, 0, 1);
                dateRange.end = new Date(todayYear, 5, 30);
            }
            else
            {
                dateRange.start = new Date(todayYear, 6, 1);
                dateRange.end = new Date(todayYear, 11, 31);
            }
        }
        else if (fanwei == "benjidu")
        {
            if (todayMonth < 3)
            {
                dateRange.start = new Date(todayYear, 0, 1);
                dateRange.end = new Date(todayYear, 2, 31);
            }
            if (todayMonth < 6)
            {
                dateRange.start = new Date(todayYear, 3, 1);
                dateRange.end = new Date(todayYear, 5, 30);
            }
            if (todayMonth < 9)
            {
                dateRange.start = new Date(todayYear, 6, 1);
                dateRange.end = new Date(todayYear, 8, 30);
            }
            else
            {
                dateRange.start = new Date(todayYear, 9, 1);
                dateRange.end = new Date(todayYear, 11, 31);
            }
        }
        else if (fanwei == "benyue")
        {
            dateRange.start = new Date(todayYear, todayMonth, 1);
            dateRange.end = new Date(todayYear, todayMonth, thisMonthDays);
        }
        else if (fanwei == "benzhou")
        {
            var days = 1 - dayOfWeek;
            if (dayOfWeek == 0)
            {
                days = -6;
            }
            dateRange.start = new Date();
            dateRange.start.setDate(todayDate + days);

            days = 7 - dayOfWeek;
            if (dayOfWeek == 0)
            {
                days = 0;
            }
            dateRange.end = new Date();
            dateRange.end.setDate(todayDate + days);
        }
        else if (fanwei == "dangtian")
        {
            dateRange.start = dateRange.end = today;
        }
        else if (fanwei == "niandu")
        {
            dateRange.start = new Date(todayYear, 0, 1);
            dateRange.end = new Date(todayYear, 11, 31);
        }
        return dateRange;
    }
});
$.widget(
    "ui.ajaxProgress", {
        options: {
        },
        _create: function(){
            var _this = this;
            var self = this.element;
            self.hide();
            
            this.element.ajaxComplete(function(event,request, settings){
                $(this).hide();
            });
            
            this.element.ajaxSend(function(event,request, settings){
                _this.show();
            });
        },
        show: function(){
            this.element.css({ top: 0, left: 0 }).show();
            
			this.element.position({
			    my: "center center",
			    at: "center center",
				of: window,
				offset: "0 0",
				collision: 'fit'
			});
        }
    }
);

$.ajaxSetup ({
    cache: false
});

$(function () {
    $("<div class='loading'></div>").appendTo($("body")).ajaxProgress();
});