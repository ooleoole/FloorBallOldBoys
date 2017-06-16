/*! jQuery UI - v1.12.1 - 2016-09-15
* http://jqueryui.com
* Copyright jQuery Foundation and other contributors; Licensed  */
!function(a) {
    "function" == typeof define && define.amd ? define(["../widgets/datepicker"], a) : a(jQuery.datepicker)
}(function(a) {
    return a.regional.gl =
    {
        closeText: "Pechar",
        prevText: "&#x3C;Ant",
        nextText: "Seg&#x3E;",
        currentText: "Hoxe",
        monthNames:
        [
            "Xaneiro", "Febreiro", "Marzo", "Abril", "Maio", "Xuño", "Xullo", "Agosto", "Setembro", "Outubro",
            "Novembro", "Decembro"
        ],
        monthNamesShort: ["Xan", "Feb", "Mar", "Abr", "Mai", "Xuñ", "Xul", "Ago", "Set", "Out", "Nov", "Dec"],
        dayNames: ["Domingo", "Luns", "Martes", "Mércores", "Xoves", "Venres", "Sábado"],
        dayNamesShort: ["Dom", "Lun", "Mar", "Mér", "Xov", "Ven", "Sáb"],
        dayNamesMin: ["Do", "Lu", "Ma", "Mé", "Xo", "Ve", "Sá"],
        weekHeader: "Sm",
        dateFormat: "dd/mm/yy",
        firstDay: 1,
        isRTL: !1,
        showMonthAfterYear: !1,
        yearSuffix: ""
    }, a.setDefaults(a.regional.gl), a.regional.gl
});