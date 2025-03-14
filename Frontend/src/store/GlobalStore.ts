import { defineStore } from 'pinia';

export const useGlobalStore = defineStore('globalStore', {
  state: () => ({
    values: {} as Record<string, any>,
  }),
  actions: {
    setValue(key: string, value: any) {
      this.values[key] = value;
    },
    getValue(key: string) {
      return this.values[key];
    },
    clearValue(key: string) {
      delete this.values[key];
    },
  },
});
