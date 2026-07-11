export class ValidacaoService {
    static validateCpf(value: string) : boolean {
        throw new Error("Method not implemented.");
    }
    static validateId(id: string): boolean {
        const idNumber = parseInt(id, 10);
        return !isNaN(idNumber) && idNumber > 0;
    }
}