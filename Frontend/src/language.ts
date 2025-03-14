import { createI18n } from 'vue-i18n';

// 언어 파일을 가져옵니다.
import en from './locales/en.json';
import ko from './locales/ko.json';

// Vue I18n 인스턴스를 생성합니다.
const i18n = createI18n({
  legacy:false,
  locale: 'ko', // 기본 언어 설정
  messages: {
    en,
    ko,
  },
});

export default i18n;
