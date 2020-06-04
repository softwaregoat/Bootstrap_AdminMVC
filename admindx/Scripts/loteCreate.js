$(function () {
    // Enable Live Search.
    $('#asignacion').attr('data-live-search', true);

    //// Enable multiple select.
    $('#asignacion').attr('multiple', true);
    $('#asignacion').attr('data-selected-text-format', 'count');

    $('.selectUsuarios').selectpicker(
        {
            width: '100%',
            title: '- [Seleccione multiple usuarios] -',
            language: 'es',
            iconBase: 'fa',
            tickIcon: 'fa-check'
        });

    $('select').selectpicker();

    $("#id_proyecto").change(function () {
        cargaSubdependencia();
        cargaSubserie();
        cargaUsuarios();
    });
    function cargaUsuarios() {
        $.ajax({
            url: '../usuario_perfil/proyUsuarios?idProyecto=' + $("#id_proyecto").val(),
            dataType: 'json',
            success: function (data) {
                //console.log(data[0].encontrado);console.log(data[1].items);
                $("#asignacion").empty();
                if (data[0].encontrado == true) {
                    $.each(data[1].items, function (i, item) {
                        console.log(item);
                        $("#asignacion").append('<option value="' + item[0] + '">' + item[1] + '</option>');
                    })
                    $('.selectUsuarios').selectpicker('render');
                    $('.selectUsuarios').selectpicker('refresh');
                }
            }
        });
    }
    function cargaSubserie() {
        $.ajax({
            url: '../p_subserie/proysuberie?idProyecto=' + $("#id_proyecto").val(),
            dataType: 'json',
            success: function (data) {
                //console.log(data[0].encontrado);console.log(data[1].items);
                $("#id_subserie").empty();
                if (data[0].encontrado == true) {
                    $.each(data[1].items, function (i, item) {
                        console.log(item);
                        console.log(item[0]);
                        $("#id_subserie").append('<option value="' + item[0] + '">' + item[1] + '</option>');
                    })
                    $('.selectSubserie').selectpicker('render');
                    $('.selectSubserie').selectpicker('refresh');
                }
            }
        });
    }
    function cargaSubdependencia() {
        $.ajax({
            url: '../p_subdependencia/proysubdependencia?idProyecto=' + $("#id_proyecto").val(),
            dataType: 'json',
            success: function (data) {
                //console.log(data[0].encontrado);console.log(data[1].items);
                $("#id_subdependencia").empty();
                if (data[0].encontrado == true) {
                    $.each(data[1].items, function (i, item) {
                        console.log(item);
                        console.log(item[0]);
                        $("#id_subdependencia").append('<option value="' + item[0] + '">' + item[1] + '</option>');
                    })
                    $('.selectSubdependencia').selectpicker('render');
                    $('.selectSubdependencia').selectpicker('refresh');
                }
            }
        });
    }
    cargaSubdependencia();
    cargaSubserie();
    cargaUsuarios();
});
