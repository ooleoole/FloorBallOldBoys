/*! jQuery UI - v1.12.1 - 2016-09-15
* http://jqueryui.com
* Copyright jQuery Foundation and other contributors; Licensed  */
!function(a) {
    "function" == typeof define && define.amd ? define(["../widgets/datepicker"], a) : a(jQuery.datepicker)
}(function(a) {
    return a.regional.nb =
    {
        closeText: "Lukk",
        prevText: "&#xAB;Forrige",
        nextText: "Neste&#xBB;",
        currentText: "I dag",
        monthNames:
        [
            "januar", "februar", "mars", "april", "mai", "juni", "juli", "august", "september", "oktober", "november",
            "desember"
        ],
        monthNamesShort: ["jan", "feb", "mar", "apr", "mai", "jun", "jul", "aug", "sep", "okt", "nov", "des"],
        dayNamesShort: ["søn", "man", "tir", "ons", "tor", "fre", "lør"],
        dayNames: ["søndag", "mandag", "tirsdag", "onsdag", "torsdag", "fredag", "lørdag"],
        dayNamesMin: ["sø", "ma", "ti", "on", "to", "fr", "lø"],
        weekHeader: "Uke",
        dateFormat: "dd.mm.yy",
        firstDay: 1,
        isRTL: !1,
        showMonthAfterYear: !1,
        yearSuffix: ""
    }, a.setDefaults(a.regional.nb), a.regional.nb
});