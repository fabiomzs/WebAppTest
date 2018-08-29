$(function () {
    addRow();

    var AppLockViewModel;
    var Items = [];

    AppLockViewModel = { Nome: "App - Lock", Items: Items };

    $("#btn-save").click(function () {

        getItems();

        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/home/index',
            data: AppLockViewModel,
            success: function (data) {
                console.log(data);
            },
            error: function (error) {
                console.log(error);
            }
        });

    });

    $("#btn-calc").click(function () {
        
        var total = 0;

        getItems();        
        console.log(AppLockViewModel.Items.lenght);
        $(AppLockViewModel.Items).each(function (i, row) {
            console.log(row);
            var inicio = moment(row.DataString + row.Ent, 'DD/MM/YYYYHH:mm');
            var fim = moment(row.DataString + row.Sai, 'DD/MM/YYYYHH:mm');
            var intervalo = row.Int;


            var dur1 = moment.duration(fim.diff(inicio));

            var sum = dur1.asMinutes() - intervalo;

            total += sum;

            console.log(total);
        });

        $(".lead").text(moment.duration(total, "minutes").format("hh:mm"));
    });

    function getItems() {        
        //AppLockViewModel.Items = [];
        Items = [];
        $('#tbl-items > tbody > tr').each(function (i, row) {

            var desc = $(row).find('input[name*="slc-e1"]').val();
            var hora = $(row).find('select[name*="slc-s1"]').val();

            var item = {
                Codigo: $(row).find('input[name*="txt-codigo"]').val(),
                Descricao: 'Teste',
                Hora: '8',
                Data: moment(desc + hora, 'DD/MM/YYYYHHmm').format('DD/MM/YYYY HH:mm'),
                DataString: $(row).find('input[name*="txt-desc"]').val(),
                Ent: $(row).find('select[name*="slc-ent"]').val(),
                Sai: $(row).find('select[name*="slc-sai"]').val(),
                Int: $(row).find('select[name*="slc-int"]').val()
                
            };

            Items.push(item);
            
        });

        AppLockViewModel.Items = Items;
    }

    $(document).on('click', 'button.deleterow', function () {
        console.log('click');
        $(this).closest('tr').remove();
        return false;
    });

    $(document).on('click', 'button.addrow', function () {
        addRow();        
        $(this).hide().next().show();               
    });
});

function addRow() {
    $('#tbl-items tbody:first').append("<tr>" +
        "<td><input class='form-control' name='txt-codigo'/></td>" +
        "<td><input name='txt-desc' value='" + getNextDate() + "' class='form-control datepicker'/></td>" +
        "<td><select name='slc-ent' class='form-control'>" + getHours() + "</select></td>" +
        "<td><select name='slc-sai' class='form-control'>" + getHours() + "</select></td>" +
        "<td><select name='slc-int' class='form-control'>" + getInterval() + "</select></td>" +
        "<td> " +
        "<button class='btn btn-sm btn-primary addrow'><span class='glyphicon glyphicon-plus'></span></button>" +
        "<button class='btn btn-sm btn-danger deleterow' style='display: none;'><span class='glyphicon glyphicon-minus'></span></button>" +
        "</td></tr>");

    getNextDate();

    setDatePicker();
}

function getHours() {
    var html = '<option></option>"';
    for (var i = 6; i < 24; i++) {
        var hora, hora2 = "";

        if (i < 0) {
            hora = "0" + i + ":00";
            hora2 = "0" + i + ":30";
        } else {
            hora = i + ":00";
            hora2 = i + ":30";
        }
        //console.log(hora);
        html += "<option value='" + hora + "'>" + hora + "</option>";
        html += "<option value='" + hora2 + "'>" + hora2 + "</option>";
    }

    return html;
}

function getInterval() {
    var html = '<option value"0"></option>';
    for (var i = 15; i <= 60; i = i + 15) {
        var minutes = '';

        if (i < 10) {
            minutes = "0" + i;
        } else {
            minutes = i;
        }

        html += "<option value='" + minutes + "'>" + minutes + "</option>";
    }

    return html;
}

function getNextDate() {
    var date = moment($('#tbl-items > tbody > tr:last').find('[name="txt-desc"]').val(), 'DD/MM/YYYY').add(1, 'd');

    if (date.isValid() === false) {
        date = moment();
    }

    return date.format('DD/MM/YYYY');
}

function sumHours(date, e1, s1, e2, s2) {
    var p1 = moment(date + e1, 'DD/MM/YYYYHH:mm');
    var p2 = moment(date + s1, 'DD/MM/YYYYHH:mm');
    var p3 = moment(date + e2, 'DD/MM/YYYYHH:mm');
    var p4 = moment(date + s2, 'DD/MM/YYYYHH:mm');          

    var dur1 = moment.duration(p2.diff(p1));
    var dur2 = moment.duration(p4.diff(p3));

    var total = dur1.asMinutes() + dur2.asMinutes();
    
    //console.log(dur1.asSeconds());
    //console.log(total);
    //console.log('--->' + moment.duration(total, "minutes").format("hh:mm"));
}

function setDatePicker() {
    $('.datepicker').datepicker({
        language: 'pt-BR',
        format: 'dd/mm/yyyy',
        startDate: '-30d'
    });
}
