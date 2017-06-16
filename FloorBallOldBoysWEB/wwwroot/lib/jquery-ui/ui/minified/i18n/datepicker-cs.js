/*! jQuery UI - v1.12.1 - 2016-09-15
* http://jqueryui.com
* Copyright jQuery Foundation and other contributors; Licensed  */
!function(a) {
    "function" == typeof define && define.amd ? define(["../widgets/datepicker"], a) : a(jQuery.datepicker)
}(function(a) {
    return a.regional.cs =
    {
        closeText: "Zavřít",
        prevText: "&#x3C;Dříve",
        nextText: "Později&#x3E;",
        currentText: "Nyní",
        monthNames: [
            "leden", "únor", "březen", "duben", "květen", "červen", "červenec", "srpen", "září", "říjen", "listopad",
            "prosinec"
        ],
        monthNamesShort: ["led", "úno", "bře", "dub", "kvě", "čer", "čvc", "srp", "zář", "říj", "lis", "pro"],
        dayNames: ["neděle", "pondělí", "úterý", "středa", "čtvrtek", "pátek", "sobota"],
        dayNamesShort: ["ne", "po", "út", "st", "čt", "pá", "so"],
        dayNamesMin: ["ne", "po", "út", "st", "čt", "pá", "so"],
        weekHeader: "Týd",
        dateFormat: "dd.mm.yy",
        firstDay: 1,
        isRTL: !1,
        showMonthAfterYear: !1,
        yearSuffix: ""
    }, a.setDefaults(a.regional.cs), a.regional.cs
});