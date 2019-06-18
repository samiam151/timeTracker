/**
 * @property {HTMLElement} element
 */
class Timer {
    /**
     * 
     * @param {HTMLElement} element 
     */
    constructor(element) {
        if (element === null || element === undefined) {
            throw new Error("Must provide an element;");
        }
        this.element = element;
        this.startButton = this.element.querySelector(".startButton");
        this.stopButton = this.element.querySelector(".stopButton");

        this.initalTime = null;
        this.finalTime = null;
    }

    /**
     * 
     * @param {Date} time1 
     * @param {Date} time2 
     */
    calculateTimeSpent(time1, time2) {
        let difference = time2 - time1;
        return difference;
    }
}
