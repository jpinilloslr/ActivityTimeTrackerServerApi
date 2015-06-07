(function() {
    var mainModule = angular.module("att.main");

    var DashboardController = function($scope, measures) {
        $scope.measures = measures;

        var getMeasuresByNames = function(names) {
            var result = [];
            
            for (var i = 0; i < measures.length; i++) {
                var measure = measures[i];
                if (-1 != names.indexOf(measure.name)) {
                    result.push(measure);
                }
            }
            return result;
        };

        var excludeMeasures = function(list, items) {
            for (var i = 0; i < items.length; i++) {
                var current = items[i];
                list.splice(list.indexOf(current), 1);
            }
            return list;
        };

        //Projects
        var projectsGraph = new DashboardGadget.StackedGraph();
        projectsGraph.setName("Projects");
        projectsGraph.setContainerId("slot4");
        projectsGraph.setMeasures(getMeasuresByNames(["ATT Implementation", "Restaurant modeling", "Restaurant implementation", "BIAdviser", "Munchies Implementation"]));

        projectsGraph.setShowTotalTime(false);
        projectsGraph.setShowAccumulationTime(true);
        projectsGraph.setShowMonthTime(true);
        projectsGraph.setShowTodayTime(true);        
        projectsGraph.draw();
        
        //Ides
        var idesGraph = new DashboardGadget.PieGraph();
        idesGraph.setName("Techs and tools");
        idesGraph.setContainerId("slot5");
        idesGraph.setMeasures(getMeasuresByNames(["VisualStudio usage", "PhpStorm usage", "Eclipse usage", "Notepad++ usage", "AndroidStudio usage"]));

        idesGraph.setShowTotalTime(true);
        idesGraph.setShowAccumulationTime(false);
        idesGraph.setShowMonthTime(false);
        idesGraph.setShowTodayTime(false);
        idesGraph.draw();
        
        //Coding today
        var codingTodayGauge = new DashboardGadget.SolidGauge();
        codingTodayGauge.setName("Coding today");
        codingTodayGauge.setContainerId("slot2");
        codingTodayGauge.max = 24;
        codingTodayGauge.setMeasures(getMeasuresByNames(["Coding"]));

        codingTodayGauge.setShowTotalTime(false);
        codingTodayGauge.setShowAccumulationTime(false);
        codingTodayGauge.setShowMonthTime(false);
        codingTodayGauge.setShowTodayTime(true);
        codingTodayGauge.draw();
        
        //Working today
        var workingTodayGauge = new DashboardGadget.SolidGauge();
        workingTodayGauge.setName("Working today");
        workingTodayGauge.setContainerId("slot3");
        workingTodayGauge.max = 24;
        workingTodayGauge.setMeasures(getMeasuresByNames(["Working"]));

        workingTodayGauge.setShowTotalTime(false);
        workingTodayGauge.setShowAccumulationTime(false);
        workingTodayGauge.setShowMonthTime(false);
        workingTodayGauge.setShowTodayTime(true);
        workingTodayGauge.draw();
        
        //All activities        
        excludeMeasures(measures, projectsGraph.getMeasures());
        excludeMeasures(measures, codingTodayGauge.getMeasures());
        excludeMeasures(measures, workingTodayGauge.getMeasures());
        excludeMeasures(measures, idesGraph.getMeasures());

        var othersGraph = new DashboardGadget.StackedGraph();
        othersGraph.setName("Other activities");
        othersGraph.setContainerId("slot1");
        othersGraph.setMeasures(measures);

        othersGraph.setShowTotalTime(false);
        othersGraph.setShowAccumulationTime(true);
        othersGraph.setShowMonthTime(true);
        othersGraph.setShowTodayTime(true);
        othersGraph.draw();
        
    };

    mainModule.controller("DashboardController", [
        '$scope',
        'measures',
        DashboardController
    ]);
})();