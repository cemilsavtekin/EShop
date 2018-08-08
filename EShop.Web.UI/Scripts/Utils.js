//bu metodt asenkron çalışacak yani burası çalışırken uygulama çalışmasına devam edecek
function AjaxPost(loadFrom, parameters, successFunc, errorFunc) {
    $.ajax
        (
            {
                url: loadFrom,
                data: parameters,
                contentType: "application/json",
                type: 'POST',
                success: successFunc,
                error:errorFunc
            });
        
}

//burada bu metot işlemini bitirene kadar bekleyecek
function AjaxPostNoAsync(loadFrom, parameters, successFunc, errorFunc) {
    $.ajax
        (
            {
                async:false,
                url: loadFrom,
                data: parameters,
                contentType: "application/json",
                type: 'POST',
                success: successFunc,
                error: errorFunc
            });

}

function AjaxPostFile(loadFrom, parameters, successFunc, errorFunc) {
    $.ajax
        (
            {
                async: false,
                url: loadFrom,
                data: parameters,
                contentType: false,
                processData:false,
                type: 'POST',
                success: successFunc,
                error: errorFunc
            });

}