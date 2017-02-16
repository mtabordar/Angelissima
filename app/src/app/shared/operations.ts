export default class Operations {
    static calculateAfterPercentage(origVal: number) {
        return Math.floor(origVal + (origVal * (30 / 100)));
    }
}