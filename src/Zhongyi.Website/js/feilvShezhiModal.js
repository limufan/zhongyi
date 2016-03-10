(function($){
    $.widget("ui.feilvShezhiModal", {
            options: {
                
	        },
	        _create: function(){
                var thiz = this;
                this._modal = this.element.modal({ show: false, backdrop: "static" }).data("bs.modal");
                this._form = this.element.find("form").form().data("form");
                this.element.find(".btnOk").click(function(){
                    if(thiz._form.validate()){
                        var value = thiz._form.getValue();
                        thiz._callback(value);
                        thiz._modal.hide();
                    }
                    return false;
                });
	        },
            show: function(callback, value){
                this._modal.show();
                this._callback = callback;
                this._form.reset();
                if(value){
                    this._form.setValue(value);
                }
            }
        }
    );
})(jQuery);