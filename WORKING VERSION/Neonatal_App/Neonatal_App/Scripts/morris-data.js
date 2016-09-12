$(function () {

    // Morris.Area({
    //     element: 'morris-area-chart',
    //     data: [{
    //         ward: '1',
    //         Premature: 66,
    //         Labor:17,
    //         Preventable: 17,
    //         Other: 0
    //     }, {
    //         ward: '2',
    //         Premature: 58,
    //         Labor:13,
    //         Preventable: 16,
    //         Other: 13
    //     }, {
    //         ward: '3',
    //         Premature: 60,
    //         Labor: 10,
    //         Preventable: 5,
    //         Other: 25
    //     }, {
    //         ward: '4',
    //         Premature: 65,
    //         Labor: 17,
    //         Preventable: 9,
    //         Other: 9
    //     }, {
    //         ward: '5',
    //         Premature: 41,
    //         Labor: 14,
    //         Preventable: 35,
    //         Other: 10
    //     }, {
    //         ward: '6',
    //         Premature: 55,
    //         Labor: 15,
    //         Preventable: 15,
    //         Other: 15
    //     }, {
    //         ward: '7',
    //         Premature: 65,
    //         Labor: 9,
    //         Preventable: 13,
    //         Other: 13
    //     }, {
    //         ward: '8',
    //         Premature: 59,
    //         Labor: 9,
    //         Preventable: 18,
    //         Other: 14
    //     }, {
    //         ward: '9',
    //         Premature: 57,
    //         Labor: 17,
    //         Preventable: 17,
    //         Other: 9
    //     }, {
    //         ward: '10',
    //         Premature: 82,
    //         Labor: 14,
    //         Preventable: 5,
    //         Other: 0
    //     }, {
    //         ward: '11',
    //         Premature: 55,
    //         Labor: 25,
    //         Preventable: 10,
    //         Other: 10
    //     }, {
    //         ward: '12',
    //         Premature: 63,
    //         Labor: 5,
    //         Preventable: 21,
    //         Other: 11
    //     }, {
    //         ward: '13',
    //         Premature: 67,
    //         Labor: 20,
    //         Preventable: 13,
    //         Other: 0
    //     }, {
    //         ward: '14',
    //         Premature: 48,
    //         Labor: 29,
    //         Preventable: 19,
    //         Other: 5
    //     }, {
    //         ward: '15',
    //         Premature: 30,
    //         Labor: 26,
    //         Preventable: 30,
    //         Other: 15
    //     }, {
    //         ward: '16',
    //         Premature: 59,
    //         Labor: 12,
    //         Preventable: 6,
    //         Other: 24
    //     }, {
    //         ward: '17',
    //         Premature: 60,
    //         Labor: 7,
    //         Preventable: 27,
    //         Other: 7
    //     }],
    //     xkey: 'ward',
    //     ykeys: ['Premature', 'Labor', 'Preventable', 'Other'],
    //     labels: ['Premature', 'Labor', 'Preventable', 'Other'],
    //     pointSize: 2,
    //     hideHover: 'auto',
    //     resize: true
    // });

    // Morris.Donut({
    //     element: 'morris-donut-chart',
    //     data: [{
    //         label: "",
    //         value:
    //     }, {
    //         label: "",
    //         value:
    //     }, {
    //         label: "",
    //         value:
    //     }],
    //     resize: true
    // });

    Morris.Bar({
        element: 'morris-bar-chart',
        data: [{
            Ward: '1',
            Premature: 66,
            Labor: 17,
            Preventable: 17,
            Other: 0
        }, {
            Ward: '2',
            Premature: 58,
            Labor: 13,
            Preventable: 16,
            Other: 13
        }, {
            Ward: '3',
            Premature: 60,
            Labor: 10,
            Preventable: 5,
            Other: 25
        }, {
            Ward: '4',
            Premature: 65,
            Labor: 17,
            Preventable: 9,
            Other: 9
        }, {
            Ward: '5',
            Premature: 41,
            Labor: 14,
            Preventable: 35,
            Other: 10
        }, {
            Ward: '6',
            Premature: 55,
            Labor: 15,
            Preventable: 15,
            Other: 15
        }, {
            Ward: '7',
            Premature: 65,
            Labor: 9,
            Preventable: 13,
            Other: 13
        }, {
            Ward: '8',
            Premature: 59,
            Labor: 9,
            Preventable: 18,
            Other: 14
        }, {
            Ward: '9',
            Premature: 57,
            Labor: 17,
            Preventable: 17,
            Other: 9
        }, {
            Ward: '10',
            Premature: 82,
            Labor: 14,
            Preventable: 5,
            Other: 0
        }, {
            Ward: '11',
            Premature: 55,
            Labor: 25,
            Preventable: 10,
            Other: 10
        }, {
            Ward: '12',
            Premature: 63,
            Labor: 5,
            Preventable: 21,
            Other: 11
        }, {
            Ward: '13',
            Premature: 67,
            Labor: 20,
            Preventable: 13,
            Other: 0
        }, {
            Ward: '14',
            Premature: 48,
            Labor: 29,
            Preventable: 19,
            Other: 5
        }, {
            Ward: '15',
            Premature: 30,
            Labor: 26,
            Preventable: 30,
            Other: 15
        }, {
            Ward: '16',
            Premature: 59,
            Labor: 12,
            Preventable: 6,
            Other: 24
        }, {
            Ward: '17',
            Premature: 60,
            Labor: 7,
            Preventable: 27,
            Other: 7
        }],

        xkey: 'Ward',
        ykeys: ['Premature', 'Labor', 'Preventable', 'Other'],
        labels: ['Premature', 'Labor', 'Preventable', 'Other'],
        hideHover: 'auto',
        resize: true
    });

});