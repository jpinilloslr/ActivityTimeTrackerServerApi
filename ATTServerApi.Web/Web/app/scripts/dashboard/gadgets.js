

(function() {
    window.DashboardGadget = {};
    var DashboardGadget = window.DashboardGadget;

    /**
    * o------------------------------------------------------------------------------o
    * |                              Generic Gadget                                  |
    * o------------------------------------------------------------------------------o
    */
    DashboardGadget.GenericGadget = function () {
        this._name = "";
        this._measures = [];
        this._containerId = "";
        
        this._options = {
            credits: false,
            series: [{
                data: [],
            }]
        };

        this.showTotalTime = true;
        this.showAccumulationTime = false;
        this.showMonthTime = false;
        this.showTodayTime = false;

        this.getShowTotalTime = function ()         { return this.showTotalTime; };
        this.getShowAccumulationTime = function ()  { return this.showAccumulationTime; };
        this.getShowMonthTime = function ()         { return this.showMonthTime; };
        this.getShowTodayTime = function ()         { return this.showTodayTime; };

        this.setShowTotalTime = function (val)          { this.showTotalTime = val; };
        this.setShowAccumulationTime = function (val)   { this.showAccumulationTime = val; };
        this.setShowMonthTime = function (val)          { this.showMonthTime = val; };
        this.setShowTodayTime = function (val)          { this.showTodayTime = val; };

        this.prepareOptions = function() {

        };

        this.prepareData = function() {

        };

        this.preDraw = function () {
            this.prepareOptions();
            this.prepareData();            
        };

        this.postDraw = function() {

        };

        this.draw = function () {
            this.preDraw();
            $('#' + this._containerId).highcharts(this._options);
            this.postDraw();
        };
        
        this.setName = function (name) {
            this._name = name;
        };

        this.getName = function () {
            return this._name;
        };

        this.setMeasures = function (measures) {
            this._measures = measures;
        };

        this.getMeasures = function() {
            return this._measures;
        };
        
        this.setContainerId = function (containerId) {
            this._containerId = containerId;
        };

        this.getContainerId = function () {
            return this._containerId;
        };
        
        this.setOptions = function (options) {
            this._options = options;
        };
        
        this.mergeOptions = function (options) {
            this._options = Highcharts.merge(this._options, options);
        };
        
        this.getOptions = function () {
            return this._options;
        };
    };
    
    /**
   * o------------------------------------------------------------------------------o
   * |                               Generic Gauge                                  |
   * o------------------------------------------------------------------------------o
   */
    DashboardGadget.GenericGauge = function () {
        this.min = 0;
        this.max = 100;

        this.addOptions = function () {

        };

        this.prepareOptions = function () {
            this.mergeOptions({
                title: {
                    text: null
                },
                yAxis: {
                    stops: [
                        [0,   '#55BF3B'], // green
                        [0.3, '#DDDF0D'], // yellow
                        [0.7, '#DF5353'] // red
                    ],                    
                    min: this.min,
                    max: this.max,
                },
            });
            this.addOptions();
        };

        this.prepareData = function () {
            var measures = this.getMeasures();
            var options = this.getOptions();            

            var serieToday, serieMonth,
                serieAccumulation, serieTotal;

            if (this.getShowTodayTime()) {
                serieToday = { name: "Today", data: [] };
                options.series = [];
                options.series.push(serieToday);
            }
            else
            if (this.getShowMonthTime()) {
                serieMonth = { name: "This month", data: [] };
                options.series = [];
                options.series.push(serieMonth);
            }
            else
            if (this.getShowAccumulationTime()) {
                serieAccumulation = { name: "Rest", data: [] };
                options.series = [];
                options.series.push(serieAccumulation);
            }
            else
            if (this.getShowTotalTime()) {
                serieTotal = { name: "Total", data: [] };
                options.series = [];
                options.series.push(serieTotal);
            }
            options.series[0].data[0] = 0;
            
            for (var i = 0; i < measures.length; i++) {
                var current = measures[i];

                if (this.getShowTotalTime()) {
                    options.series[0].data[0] += current.time / 1000 / 60 / 60;
                }
                else
                if (this.getShowAccumulationTime()) {
                    options.series[0].data[0] += current.timeRestAccumulation / 1000 / 60 / 60;
                }
                else
                if (this.getShowMonthTime()) {
                    options.series[0].data[0] += current.timeMonthAccumulation / 1000 / 60 / 60;
                }
                else
                if (this.getShowTodayTime()) {
                    options.series[0].data[0] += current.timeToday / 1000 / 60 / 60;
                }
            }
        };
    };
    DashboardGadget.GenericGauge.prototype = new DashboardGadget.GenericGadget();
    DashboardGadget.GenericGauge.prototype.constructor = DashboardGadget.GenericGauge;
    
    /**
    * o------------------------------------------------------------------------------o
    * |                                Solid Gauge                                   |
    * o------------------------------------------------------------------------------o
    */
    DashboardGadget.SolidGauge = function () {
        this.addOptions = function () {
            this.mergeOptions({
                chart: {
                    type: 'solidgauge'
                },

                pane: {
                    center: ['50%', '85%'],
                    size: '100%',
                    startAngle: -90,
                    endAngle: 90,
                    background: {
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || '#EEE',
                        innerRadius: '60%',
                        outerRadius: '100%',
                        shape: 'arc'
                    }
                },

                tooltip: {
                    enabled: false
                },

                // the value axis
                yAxis: {
                    lineWidth: 0,
                    tickWidth: 0,
                    title: {
                        y: -70
                    },
                    labels: {
                        y: 16
                    },
                },
                plotOptions: {
                    solidgauge: {
                        dataLabels: {
                            y: 5,
                            borderWidth: 0,
                            enabled: true,
                            format: '{point.y:.2f} h'
                        }
                    }
                },
            });
        };

    };
    DashboardGadget.SolidGauge.prototype = new DashboardGadget.GenericGauge();
    DashboardGadget.SolidGauge.prototype.constructor = DashboardGadget.SolidGauge;
    
    /**
    * o------------------------------------------------------------------------------o
    * |                               Generic Graph                                  |
    * o------------------------------------------------------------------------------o
    */
    DashboardGadget.GenericGraph = function () {

        this.addOptions = function() {

        };

        this.prepareOptions = function() {
            this.mergeOptions({
                chart: {
                    zoomType: 'xy'
                },
                title: {
                    text: null
                },
                xAxis: {
                    type: 'category'
                },
                yAxis: {
                    title: {
                        text: 'Time in hours'
                    }
                },
                plotOptions: {
                    series: {
                        borderWidth: 0
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                    pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f} hours</b><br> ' 
                }
            });
            this.addOptions();
        };

        this.prepareData = function () {
            var measures = this.getMeasures();
            var options = this.getOptions();
            options.series = [];
            
            var serieToday, serieMonth,
                serieAccumulation, serieTotal;
            
            if (this.getShowTodayTime()) {
                serieToday = { name: "Today", data: [] };
                options.series.push(serieToday);
            }

            if (this.getShowMonthTime()) {
                serieMonth = { name: "This month", data: [] };
                options.series.push(serieMonth);
            }

            if (this.getShowAccumulationTime()) {
                serieAccumulation = { name: "Rest", data: [] };
                options.series.push(serieAccumulation);
            }

            if (this.getShowTotalTime()) {
                serieTotal = { name: "Total", data: [] };
                options.series.push(serieTotal);
            }            

            for (var i = 0; i < measures.length; i++) {
                var current = measures[i];
                
                if (this.getShowTotalTime()) {
                    var nodeTotal = {};
                    nodeTotal.name = current.name;
                    nodeTotal.y = current.time / 1000 / 60 / 60;
                    serieTotal.data.push(nodeTotal);
                }

                if (this.getShowAccumulationTime()) {
                    var nodeAccum = {};
                    nodeAccum.name = current.name;
                    nodeAccum.y = current.timeRestAccumulation / 1000 / 60 / 60;
                    serieAccumulation.data.push(nodeAccum);
                }
                
                if (this.getShowMonthTime()) {
                    var nodeMonth = {};
                    nodeMonth.name = current.name;
                    nodeMonth.y = current.timeMonthAccumulation / 1000 / 60 / 60;
                    serieMonth.data.push(nodeMonth);
                }
                
                if (this.getShowTodayTime()) {
                    var nodeToday = {};
                    nodeToday.name = current.name;
                    nodeToday.y = current.timeToday / 1000 / 60 / 60;
                    serieToday.data.push(nodeToday);
                }                
            }            
        };
    };
    DashboardGadget.GenericGraph.prototype = new DashboardGadget.GenericGadget();
    DashboardGadget.GenericGraph.prototype.constructor = DashboardGadget.GenericGraph;
    
    /**
    * o------------------------------------------------------------------------------o
    * |                               Column Graph                                   |
    * o------------------------------------------------------------------------------o
    */
    DashboardGadget.ColumnGraph = function () {
        this.addOptions = function () {
            this.mergeOptions({
                chart: {
                    type: 'column'
                },
                plotOptions: {
                    series: {
                        dataLabels: {
                            enabled: true,
                            format: '{point.y:.1f} h'
                        }
                    }
                }
            });
        };

    };
    DashboardGadget.ColumnGraph.prototype = new DashboardGadget.GenericGraph();
    DashboardGadget.ColumnGraph.prototype.constructor = DashboardGadget.ColumnGraph;
    
    /**
    * o------------------------------------------------------------------------------o
    * |                                 Bar Graph                                    |
    * o------------------------------------------------------------------------------o
    */
    DashboardGadget.BarGraph = function () {
        this.addOptions = function () {
            this.mergeOptions({
                chart: {
                    type: 'bar'
                },
                plotOptions: {
                    series: {
                        dataLabels: {
                            enabled: true,
                            format: '{point.y:.1f} h'
                        }
                    }
                }
            });
        };

    };
    DashboardGadget.BarGraph.prototype = new DashboardGadget.GenericGraph();
    DashboardGadget.BarGraph.prototype.constructor = DashboardGadget.BarGraph;
    
    /**
    * o------------------------------------------------------------------------------o
    * |                               Stacked Graph                                  |
    * o------------------------------------------------------------------------------o
    */
    DashboardGadget.StackedGraph = function () {
        this.addOptions = function() {
            this.mergeOptions({
                chart: {
                    type: 'column'
                },
                plotOptions: {
                    series: {
                        stacking: 'normal',
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                    pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f} hours</b><br> ' +
                    '<span style="color:{point.color}">Total</span>: <b>{point.stackTotal:.2f} hours</b>'
                },
                yAxis: {
                    stackLabels: {
                        enabled: true,
                        format: '{total:.2f} h'
                    }
                },
                
            });
        };
    };
    DashboardGadget.StackedGraph.prototype = new DashboardGadget.GenericGraph();
    DashboardGadget.StackedGraph.prototype.constructor = DashboardGadget.StackedGraph;
    
    /**
    * o------------------------------------------------------------------------------o
    * |                                Bar Graph                                     |
    * o------------------------------------------------------------------------------o
    */
    DashboardGadget.BarStackedGraph = function () {
        this.addOptions = function () {
            this.mergeOptions({
                chart: {
                    type: 'bar'
                },
                plotOptions: {
                    series: {
                        stacking: 'normal',
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                    pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f} hours</b><br> ' +
                    '<span style="color:{point.color}">Total</span>: <b>{point.stackTotal:.2f} hours</b>'
                },
                yAxis: {
                    stackLabels: {
                        enabled: true,
                        format: '{total:.2f} h'
                    }
                },

            });
        };

    };
    DashboardGadget.BarStackedGraph.prototype = new DashboardGadget.GenericGraph();
    DashboardGadget.BarStackedGraph.prototype.constructor = DashboardGadget.BarStackedGraph;
    
    /**
    * o------------------------------------------------------------------------------o
    * |                                Pie Graph                                     |
    * o------------------------------------------------------------------------------o
    */
    DashboardGadget.PieGraph = function () {
        this.addOptions = function () {
            this.mergeOptions({
                chart: {
                    type: 'pie'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false,                            
                        },
                        showInLegend: true
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                    pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f} hours</b><br> '
                },                

            });
        };

    };
    DashboardGadget.PieGraph.prototype = new DashboardGadget.GenericGraph();
    DashboardGadget.PieGraph.prototype.constructor = DashboardGadget.PieGraph;

})();


