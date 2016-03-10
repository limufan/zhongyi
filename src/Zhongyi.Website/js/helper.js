function closeWindow() {
    if(!$.debug){
        window.open('', '_self', '');
        window.close();
    }
}
function submitForm(args){
    var detailsform = args.form, btnSubmit, submitUrl, callback, returnUrl
    if(args.form.validate()){
        var value = args.form.getValue();
        args.btnSubmit.prop("disabled", true);
        $.post(args.submitUrl, {argsJson: $.toJSON(value)}, function(model){
            if(model.result){
                if(args.returnUrl){
                    location = args.returnUrl;
                }
                else if(args.callback && opener[args.callback]){
                    opener[args.callback]();
                    closeWindow();
                }
                else{
                    $.messageBox.info("提交成功");
                }
            }
            else{
                $.messageBox.info(model.message);
                args.btnSubmit.prop("disabled", false);
            }
        });
    }
}
